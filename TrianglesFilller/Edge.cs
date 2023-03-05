using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TrianglesFilller
{
    internal class Edge
    { 
        public PointF P, K;
      
        public Edge(Vector4 v1,Vector4 v2)
        {
            P = new PointF(v1.X, v1.Y);
            K = new PointF(v2.X, v2.Y);
        }
    }
}
