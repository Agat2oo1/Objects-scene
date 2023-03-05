using ObjParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TrianglesFilller
{
    internal class Object3D
    {
        public List<Polygon> polygons;
        public Vector3 position { get; set; }
        private Matrix4x4 modelMatrix; 
        public Object3D(List<Polygon> polygons)
        {
            this.polygons = new List<Polygon>();
            position = Vector3.Zero;
            modelMatrix = Matrix4x4.Identity;

            foreach (Polygon polygon in polygons)
            {
                this.polygons.Add(polygon);
            }
        }
        public void CalculateModelMatrix(/*float scale, */float angle, Vector3 newPosition)
        {
            Matrix4x4 RotationMatrix = Matrix4x4.CreateRotationX(angle);
            Matrix4x4 TranslationMatrix = Matrix4x4.CreateTranslation(newPosition);

            modelMatrix = RotationMatrix * TranslationMatrix;
        }
        public void CalculateObject3D()
        {
            Matrix4x4 ViewMatrix = Matrices.viewMatrix;
            Matrix4x4 ProjectionMatrix = Matrices.projectionMatrix;

            Matrix4x4 matrix = modelMatrix * ViewMatrix * ProjectionMatrix;

            for (int i = 0; i < this.polygons.Count; i++)
            {
                List<Vector4> vertices = this.polygons[i].Vertices;
                List<Vector4> rescaleVertices = this.polygons[i].RescaleVertices;
                List<Vector3> vectors = this.polygons[i].Vectors;
                List<Vector3> rescaleVectors = this.polygons[i].RescaleVectors;

                for (int ii = 0; ii < vertices.Count; ii++)
                {
                    rescaleVertices[ii] = Vector4.Transform(vertices[ii], matrix);
                    rescaleVertices[ii] /= rescaleVertices[ii].W;
                    rescaleVectors[ii] = Vector3.TransformNormal(vectors[ii], modelMatrix);
                }
            }
        }
        public void CalculatePosition()
        {
            this.position = Vector3.Transform(Vector3.Zero, modelMatrix);
        }
    }
}
