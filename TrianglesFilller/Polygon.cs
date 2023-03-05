using ObjParser.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Color = System.Drawing.Color;

namespace TrianglesFilller
{
    internal class Polygon
    {
        public List<Vector4> Vertices;
        public List<Vector4> RescaleVertices;
        public List<Vector3> Vectors;
        public List<Vector3> RescaleVectors;
        private Color triangleColor;
        private Vector3 position;
        private Vector3 scale;
        private Vector3 lightVector;
        private Vector3 vectorV;
        private Vector3 vectorR;

        float[,] M = new float[3, 3];
        public Polygon(List<Vector4> vertices, List<Vector3> vectors, Vector3 position, Vector3 scale)
        {
            Random r = new Random();
            Vertices = new List<Vector4>();
            RescaleVertices = new List<Vector4>();
            Vectors = new List<Vector3>();
            RescaleVectors = new List<Vector3>();

            lightVector = new Vector3(0, 0, 0);
            vectorR = new Vector3(0, 0, 0);
            vectorV = new Vector3(0, 0, 1);

            foreach (var v in vertices)
            {
                Vertices.Add(v);
                RescaleVertices.Add(v);
            }

            foreach (var vn in vectors)
            {
                Vectors.Add(Vector3.Normalize(vn));
                RescaleVectors.Add(Vector3.Normalize(vn));
            }

            triangleColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            this.position = position;
            this.scale = scale;
        }

        public List<Pixel> Pixels()
        {
            List<Pixel> pixels = new List<Pixel>();
            int y, i, j = -1;

            for (i=0;i< Vertices.Count;i++)
            {
                RescaleVertices[i] = Vector4.Transform(RescaleVertices[i], Matrix4x4.CreateScale(scale));
                RescaleVertices[i] = Vector4.Transform(RescaleVertices[i], Matrix4x4.CreateTranslation(position));

                if (RescaleVertices[i].X < 0 || (int)RescaleVertices[i].X >= ProjectData.pictureBox.Width 
                    || RescaleVertices[i].Y < 0 || (int)RescaleVertices[i].Y >= ProjectData.pictureBox.Height) return pixels;  
            }

            List<Item>[] EdgeTable = Bucket(RescaleVertices);
            List<Item> ActiveEdgeTable = new List<Item>();
            while (EdgeTable[++j].Count == 0) ;
            y = j;

            ActiveEdgeTable.Clear();

            do
            {
                ActiveEdgeTable.AddRange(EdgeTable[y]);
                
                ActiveEdgeTable.Sort(delegate (Item i1, Item i2)
                {
                    return i1.xMin.CompareTo(i2.xMin);
                });


                //  wypełnij piksele pomiędzy parami przecięć
                for (i = 1; i < ActiveEdgeTable.Count; i++)
                {
                    float x1 = ActiveEdgeTable[i - 1].xMin;
                    float x2 = ActiveEdgeTable[i].xMin;
                    for (; x1 <= x2; x1++)
                    {
                        pixels.Add(new Pixel((int)x1, y));
                    }

                }
                for (j = ActiveEdgeTable.Count - 1; j >= 0; j--)
                {
                    if (((int)ActiveEdgeTable[j].yMax) == y)
                    {
                        ActiveEdgeTable.RemoveAt(j);
                    }
                }

                y++;

                foreach (var aet in ActiveEdgeTable)
                {
                    aet.xMin += aet.dxdy;
                }

            } while (ActiveEdgeTable != null && y < EdgeTable.Length);

            return pixels;
        }
        private static List<Item>[] Bucket(List<Vector4> transformVertices)
        {
            int maxValue = (int)transformVertices.Max(v => v.Y);

            List<Item>[] buckets = new List<Item>[maxValue + 1];

            for (int i = 0; i <= maxValue; i++)
            {
                buckets[i] = new List<Item>();
            }

            for (int i = 0; i < transformVertices.Count; i++)
            {
                int j = (i + 1) % transformVertices.Count;
                Vector4 v1, v2;
                if (transformVertices[i].Y <= transformVertices[j].Y)
                {
                    v1 = transformVertices[i];
                    v2 = transformVertices[j];
                }
                else
                {
                    v1 = transformVertices[j];
                    v2 = transformVertices[i];
                }
                int y = (int)v1.Y;
                float dxdy = (v2.Y - y) != 0 ? (v2.X - v1.X) / (v2.Y - y) : 0;
                buckets[y].Add(new Item(v2.Y, v1.X, dxdy));
            }
            return buckets;
        }
        public Color CountColor(float x, int y)
        {
            Vector3 vn;
            float s;
            float z = ZValue(x, y); // tu jeszcze do mgły odjąć albo dodać Z kamery!!!
            float f = 0;
            float Start = 10f;    // Linear fog distances
            float End = 100f;

            if (ProjectData.fog)
            {
                f = (z - ProjectData.cameraZ)/100f;
                f *= ProjectData.fog_density;
            }

            switch (ProjectData.colorOption)
            {
                case 0:
                    return triangleColor;
                case 1:
                    for (int i = 0; i < Vertices.Count; i++)
                    {
                        vn = RescaleVectors[i];
                        Vector3.Normalize(vn);

                        lightVector.X = Settings.x_sun - RescaleVertices[i].X;
                        lightVector.Y = Settings.y_sun - RescaleVertices[i].Y;
                        lightVector.Z = Settings.z_sun - RescaleVertices[i].Z;
                        lightVector = Vector3.Normalize(lightVector);

                        s = 2 * Vector.Scalar(vn, lightVector);
                        vectorR = vn * s - lightVector;
                        vectorR = Vector3.Normalize(vectorR);

                        M[i, 0] = CountColorComponent(vn, Settings.objectColor_R, Settings.sunColor_R, lightVector, vectorR, vectorV) + f;
                        M[i, 1] = CountColorComponent(vn, Settings.objectColor_G, Settings.sunColor_G, lightVector, vectorR, vectorV) + f;
                        M[i, 2] = CountColorComponent(vn, Settings.objectColor_B, Settings.sunColor_B, lightVector, vectorR, vectorV) + f;
                    }
                    (float, float, float) coordinates = BarycentricCoordinate(x, y);

                    float I_R = M[0, 0] * coordinates.Item1 + M[1, 0] * coordinates.Item2 + M[2, 0] * coordinates.Item3;
                    float I_G = M[0, 1] * coordinates.Item1 + M[1, 1] * coordinates.Item2 + M[2, 1] * coordinates.Item3;
                    float I_B = M[0, 2] * coordinates.Item1 + M[1, 2] * coordinates.Item2 + M[2, 2] * coordinates.Item3;

                    I_R *= 255;
                    I_G *= 255;
                    I_B *= 255;

                    I_R = I_R <= 255 ? I_R : 255;
                    I_R = I_R >= 0 ? I_R : 0;
                    I_G = I_G <= 255 ? I_G : 255;
                    I_G = I_G >= 0 ? I_G : 0;
                    I_B = I_B <= 255 ? I_B : 255;
                    I_B = I_B >= 0 ? I_B : 0;

                    return Color.FromArgb(255, (int)I_R, (int)I_G, (int)I_B);
                case 2:
                    vn = VectorInterpolation(x, y);
                    Vector3.Normalize(vn);

                    lightVector.X = Settings.x_sun - x;
                    lightVector.Y = Settings.y_sun - y;
                    lightVector.Z = Settings.z_sun - z;
                    lightVector = Vector3.Normalize(lightVector);

                    s = 2 * Vector.Scalar(vn, lightVector);
                    vectorR = vn * s - lightVector;
                    vectorR = Vector3.Normalize(vectorR);

                    float IR = CountColorComponent(vn, Settings.objectColor_R, Settings.sunColor_R, lightVector, vectorR, vectorV) + f;
                    float IG = CountColorComponent(vn, Settings.objectColor_G, Settings.sunColor_G, lightVector, vectorR, vectorV) + f;
                    float IB = CountColorComponent(vn, Settings.objectColor_B, Settings.sunColor_B, lightVector, vectorR, vectorV) + f;

                    IR *= 255;
                    IG *= 255;
                    IB *= 255;
                    IR = IR <= 255 ? IR : 255;
                    IR = IR >= 0 ? IR : 0;
                    IG = IG <= 255 ? IG : 255;
                    IG = IG >= 0 ? IG : 0;
                    IB = IB <= 255 ? IB : 255;
                    IB = IB >= 0 ? IB : 0;
                    return Color.FromArgb(255, (int)IR, (int)IG, (int)IB);
                default:
                    return Color.White;
            }
        }
        public (float, float, float) BarycentricCoordinate(float x, int y)
        {
            float w1, w2, w3;
            w1 = ((RescaleVertices[1].Y - RescaleVertices[2].Y) * (x - RescaleVertices[2].X) + (RescaleVertices[2].X - RescaleVertices[1].X) * (y - RescaleVertices[2].Y))
                / ((RescaleVertices[1].Y - RescaleVertices[2].Y) * (RescaleVertices[0].X - RescaleVertices[2].X) + (RescaleVertices[2].X - RescaleVertices[1].X) * (RescaleVertices[0].Y - RescaleVertices[2].Y));
            w2 = ((RescaleVertices[2].Y - RescaleVertices[0].Y) * (x - RescaleVertices[2].X) + (RescaleVertices[0].X - RescaleVertices[2].X) * (y - RescaleVertices[2].Y))
                / ((RescaleVertices[1].Y - RescaleVertices[2].Y) * (RescaleVertices[0].X - RescaleVertices[2].X) + (RescaleVertices[2].X - RescaleVertices[1].X) * (RescaleVertices[0].Y - RescaleVertices[2].Y));
            w3 = 1 - w1 - w2;
            return (w1, w2, w3);
        }
        public float ZValue(float x, int y)
        {
            (float, float, float) coordinates = BarycentricCoordinate(x, y);
            return coordinates.Item1 * RescaleVertices[0].Z + coordinates.Item2 * RescaleVertices[1].Z + coordinates.Item3 * RescaleVertices[2].Z;
        }
        private Vector3 VectorInterpolation(float x, int y)
        {
            (float, float, float) coordinates = BarycentricCoordinate(x, y);
            return RescaleVectors[0] * coordinates.Item1 + RescaleVectors[1] * coordinates.Item2 + RescaleVectors[2]* coordinates.Item3;
        }

        private float CountColorComponent(Vector3 vn, float objectColor, float sunColor, Vector3 lightVector, Vector3 vectorR, Vector3 vectorV)
        {
            var I = Settings.k_d * sunColor * objectColor * Vector.Cos(vn,lightVector)
                + Settings.k_s * sunColor * objectColor * MathF.Pow(Vector.Cos(vectorV,vectorR), Settings.m);

            return I;
        }
      
    }
}
