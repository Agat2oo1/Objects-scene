using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesFilller
{
    internal class ProjectData
    {
        public static PictureBox pictureBox;
        public static int colorOption;
        public static bool fog;
        public static float parametr = (MathF.PI / 180f);
        public static float parametr2;
        public static Vector3 cameraUp = new Vector3(0, 1, 0);
        public static float cameraZ;
        public static float fog_density = 0;
    }
    internal class Matrices
    {
        public static Matrix4x4 modelMatrix;
        public static Matrix4x4 viewMatrix;
        public static Matrix4x4 projectionMatrix;
    }
    internal class Settings
    {
        public static float k_d;
        public static float k_s;
        public static float m;
        public static float k_a;
        public static float x_sun;
        public static float y_sun;
        public static float z_sun;
        public static float objectColor_R;
        public static float objectColor_G;
        public static float objectColor_B;
        public static float sunColor_R;
        public static float sunColor_G;
        public static float sunColor_B;
    }
}
