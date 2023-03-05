using ObjParser;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Color = System.Drawing.Color;
using Timer = System.Timers.Timer;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Reflection.Metadata;

namespace TrianglesFilller
{
    public partial class MainWindow : Form
    {
        Bitmap bitmap;
        BmpPixelSnoop snoop;
        Object3D moving;
        Vector3 newPosition = Vector3.Zero;
        float radians = 0;
        List<Object3D> objects;
        float[,] Zbuffor;
        Color backgroung;

        bool reverse { get; set; } = true;
        public MainWindow()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.Size.Width,pictureBox.Size.Height);
            pictureBox.Image = bitmap;
            ProjectData.pictureBox = pictureBox;
            ProjectData.parametr2 = (float)pictureBox.Width / (float)pictureBox.Height;
            ProjectData.cameraZ = 50;
            using (var snoop = new BmpPixelSnoop((Bitmap)pictureBox.Image))
            {
                this.snoop = snoop;
            }

            objects = new List<Object3D>();
            Zbuffor = new float[pictureBox.Size.Width, pictureBox.Size.Height];

            backgroung = Color.White;
            Settings.k_s = 0f;
            Settings.k_d = 1f;
            Settings.m = 10;
            Settings.x_sun = 100;
            Settings.y_sun = 100;
            Settings.z_sun = 1000;
            Settings.objectColor_R = Color.BlueViolet.R / 255f;
            Settings.objectColor_G = Color.BlueViolet.G / 255f;
            Settings.objectColor_B = Color.BlueViolet.B / 255f;
            Settings.sunColor_R = 1;
            Settings.sunColor_G = 1;
            Settings.sunColor_B = 1;

            PrepareScene();
            timer2.Start();
        }
        private void PrepareScene()
        {
            Obj obj = new Obj();
            Obj obj2 = new Obj();

            obj.LoadObj(@"C:..\\..\\..\\..\\fulltorus.obj");
            LoadPoints(obj, 500, 400, new Vector3(400, 400, 120));

            moving = objects[0];

            obj2.LoadObj(@"C:..\\..\\..\\..\\sphere.obj");
            LoadPoints(obj2, 850, 350, new Vector3(50, 50, 90));

            obj.LoadObj(@"C:..\\..\\..\\..\\fulltorus.obj");
            LoadPoints(obj, 500, 400, new Vector3(200, 200, 200));
        }
        private void LoadPoints(Obj obj,int centerX,int centerY,Vector3 scale)
        {
            List<Polygon> polygons = new List<Polygon>();
            List<Vector4> vectors = new List<Vector4>();
            List<Vector3> nvectors = new List<Vector3>();

            foreach (var F in obj.FaceList)
            {
                for (int i = 0; i < F.VertexIndexList.Length; i++)
                {
                    Vector4 v = new Vector4(obj.VertexList[F.VertexIndexList[i] - 1].X,
                                      obj.VertexList[F.VertexIndexList[i] - 1].Y,
                                      obj.VertexList[F.VertexIndexList[i] - 1].Z,1);

                    vectors.Add(v);

                    Vector3 vn = new Vector3(obj.NVectorList[F.NormalVectorIndexList[i] - 1].X,
                                        obj.NVectorList[F.NormalVectorIndexList[i] - 1].Y, obj.NVectorList[F.NormalVectorIndexList[i] - 1].Z);
                     nvectors.Add(vn);
                }
                polygons.Add(new Polygon(vectors,nvectors,new Vector3(centerX,centerY,0),scale));
                vectors.Clear();
                nvectors.Clear();
            }

            objects.Add(new Object3D(polygons));
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".obj files|*.obj";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Random random = new Random();
                    Obj obj = new Obj();
                    var filePath = openFileDialog1.FileName;
                    obj.LoadObj(filePath);

                    int scale = random.Next(200);
               
                    LoadPoints(obj,random.Next(788)+1,random.Next(864)+1,new Vector3(scale, scale, random.Next(300)));
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Actualize()
        {
            //Matrices.modelMatrix = Matrix4x4.CreateRotationY(radians);
            Matrices.projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(Fov.Value * ProjectData.parametr, ProjectData.parametr2, 1, 1000);

            if (camera1.Checked)
            {
                Matrices.viewMatrix = Matrix4x4.CreateLookAt(new Vector3((float)XCoordinate.Value, (float)YCoordinate.Value, (float)ZCoordinate.Value), Vector3.Zero, ProjectData.cameraUp);

            }
            if (camera2.Checked)
            {
                Matrices.viewMatrix = Matrix4x4.CreateLookAt(new Vector3((float)XCoordinate.Value, (float)YCoordinate.Value, (float)ZCoordinate.Value),
                                                                new Vector3(moving.position.X, moving.position.Y, moving.position.Z), ProjectData.cameraUp);
            }
            if (camera3.Checked)
            {
                Matrices.viewMatrix = Matrix4x4.CreateLookAt(new Vector3(moving.position.X, moving.position.Y, moving.position.Z + 20),
                                                                new Vector3(moving.position.X, moving.position.Y, moving.position.Z), ProjectData.cameraUp);
            }

            zBufferClear();
            

            foreach (var obj in objects)
            {
                obj.CalculateObject3D();
                foreach (var p in obj.polygons)
                {
                    foreach (var px in p.Pixels())
                    {
                        float z = p.ZValue(px.x, px.y);

                        if (z <= Zbuffor[px.x, px.y])
                        {
                            snoop.SetPixel(px.x, px.y, p.CountColor(px.x, px.y));
                            Zbuffor[px.x, px.y] = z;
                        }
                    }
                }
            }

            pictureBox.Refresh();
        }

        private void zBufferClear()
        {
            for(int y = 0; y < pictureBox.Height; y++)
            {
                for(int x=0; x<pictureBox.Width; x++)
                {
                    snoop.SetPixel(x, y, backgroung);
                    Zbuffor[x, y] = float.MaxValue;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (day_night.Checked)
            {
                Settings.sunColor_B -= 0.01f;
                Settings.sunColor_G -= 0.01f;
                Settings.sunColor_R -= 0.01f;
                backgroung = Color.FromArgb(backgroung.R - 3, backgroung.G - 3, backgroung.B - 3);
                if (Settings.sunColor_G < 0.2f) timer1.Stop();
            }
            else
            {
                Settings.sunColor_B += 0.01f;
                Settings.sunColor_G += 0.01f;
                Settings.sunColor_R += 0.01f;
                backgroung = Color.FromArgb(backgroung.R + 3, backgroung.G + 3, backgroung.B + 3);
                if (Settings.sunColor_G > 0.98f) timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            radians -= ProjectData.parametr;
            if (radians < 0) radians = 360 * ProjectData.parametr;
            newPosition.X = 120 - 160 * MathF.Sin(radians);
            newPosition.Z = 160 * MathF.Cos(radians);
            moving.CalculateModelMatrix(radians, newPosition);
            moving.CalculatePosition();
            Actualize();
        }

        private void ZCoordinate_ValueChanged(object sender, EventArgs e)
        {
            ProjectData.cameraZ = (float)ZCoordinate.Value;
            Actualize();
        }

        private void YCoordinate_ValueChanged(object sender, EventArgs e)
        {
            Actualize();
        }

        private void XCoordinate_ValueChanged(object sender, EventArgs e)
        {
            Actualize();
        }

        private void Fov_Scroll(object sender, EventArgs e)
        {
            Actualize();
        }

        private void objectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                objectColorView.BackColor = colorDialog1.Color;
                Settings.objectColor_R = colorDialog1.Color.R / 255f;
                Settings.objectColor_G = colorDialog1.Color.G / 255f;
                Settings.objectColor_B = colorDialog1.Color.B / 255f;
                Actualize();
            }
        }

        private void staticColor_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.colorOption = 0;
            Actualize();
        }

        private void Gouard_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.colorOption = 1;
            Actualize();
        }

        private void Phong_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.colorOption = 2;
            Actualize();
        }

        private void fog_CheckedChanged(object sender, EventArgs e)
        {
            //ProjectData.fog = fog.Checked;
            ProjectData.fog = true;
            timer3.Stop();
            timer3.Start();
            Actualize();
        }

        private void day_night_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (fog.Checked)
            {
                ProjectData.fog_density += 0.02f;
                if (ProjectData.fog_density > 0.97f) timer3.Stop();
            }
            else
            {
                ProjectData.fog_density -= 0.02f;
                if (ProjectData.fog_density < 0.03f)
                {
                    timer3.Stop();
                    ProjectData.fog = false;
                }
            }
        }
    }
}