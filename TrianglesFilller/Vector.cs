using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesFilller
{
    internal static class Vector
    {
        public static Vector3 vectorProduct(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                                    vector1.Z * vector2.X - vector1.X * vector2.Z,
                                    vector1.X * vector2.Y - vector1.Y * vector2.X);
        }
        public static float Scalar(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static float Cos(Vector3 vector1, Vector3 vector2)
        {
            var s = Scalar(vector1,vector2);
            return s >= 0 ? s : 0;
        }
        
    }
}
