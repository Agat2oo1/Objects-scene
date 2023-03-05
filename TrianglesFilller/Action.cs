using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TrianglesFilller
{
    internal static class Action
    {
        public static void CountTransfom()
        {
        }
        public static List<Pixel> GetPixels(List<Vector4> transformVertices)
        {
            List<Pixel> pixels = new List<Pixel>();
            if(transformVertices.Count==0) return pixels;

            int y;
            int i = -1;
            List<Item>[] EdgeTable = Bucket(transformVertices);
            List<Item> ActiveEdgeTable = new List<Item>();
            while (EdgeTable[++i].Count == 0);
            y = i;
            ActiveEdgeTable.Clear();
            
            do
            {
                //ActiveEdgeTable.AddRange(EdgeTable[y]);
                foreach(var item in EdgeTable[y])
                {
                    ActiveEdgeTable.Add(new Item(item.yMax,item.xMin,item.dxdy));
                }

                ActiveEdgeTable.Sort(delegate (Item i1, Item i2)
                {
                    return i1.xMin.CompareTo(i2.xMin);
                });


                //  wypełnij piksele pomiędzy parami przecięć
                for (i = 1; i < ActiveEdgeTable.Count; i ++)
                {
                    float x1 = ActiveEdgeTable[i - 1].xMin;
                    float x2 = ActiveEdgeTable[i].xMin;
                    for (; x1 <= x2; x1++)
                    {
                        pixels.Add(new Pixel((int)x1, y));
                    }

                }
                for (int j = ActiveEdgeTable.Count - 1; j >= 0; j--)
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

            for(int i=0; i <= maxValue; i++)
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
    }
}
