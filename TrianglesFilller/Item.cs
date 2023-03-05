using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesFilller
{
    internal class Item
    {
        public float yMax, xMin, dxdy;

        public Item(float y, float x, float d)
        {
            yMax = y;
            xMin = x;
            dxdy= d;
        }
    }
}
