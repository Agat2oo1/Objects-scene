using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesFilller
{
    internal static class MethodsForObject3D
    {
        public static void CalculateObject3D(Object3D obj, float scale, float angle, Vector3 newPosition)
        {
            Matrix4x4 RotationMatrix = Matrix4x4.CreateRotationX(angle);
            Matrix4x4 TranslationMatrix = Matrix4x4.CreateTranslation(newPosition);

            obj.position = Vector3.Transform(Vector3.Zero, RotationMatrix * TranslationMatrix);

            Matrix4x4 ViewMatrix = Matrices.viewMatrix;
            Matrix4x4 ProjectionMatrix = Matrices.projectionMatrix;

            Matrix4x4 matrix = RotationMatrix * TranslationMatrix * ViewMatrix * ProjectionMatrix;

            for(int i=0;i<obj.polygons.Count;i++){
                List<Vector4> vertices = obj.polygons[i].Vertices;
                List<Vector4> rescaleVertices = obj.polygons[i].RescaleVertices;
                List<Vector3> vectors = obj.polygons[i].Vectors;
                List<Vector3> rescaleVectors = obj.polygons[i].RescaleVectors;

                for (int ii = 0; ii < vertices.Count; ii++)
                {
                    rescaleVertices[ii] = Vector4.Transform(vertices[ii], matrix);
                    rescaleVertices[ii] /= rescaleVertices[ii].W;
                    rescaleVectors[ii] = Vector3.TransformNormal(vectors[ii], RotationMatrix * TranslationMatrix);
                }
            }
        }
    }
}
