using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using OpenTK;

using Assimp;

namespace EventDraw._3d
{
    public struct MeshInfo
    {
        public float[] vertices;
        public int[] indicate;
    }

    class ObjLoader
    {
        public static Scene LoadObjTextured(string path)
        {
            AssimpContext importer = new AssimpContext();
            Scene model = importer.ImportFile(path, PostProcessPreset.TargetRealTimeMaximumQuality);

            if (!importer.IsImportFormatSupported(Path.GetExtension(path)))
            {
                throw new ArgumentException("Model format " + Path.GetExtension(path) + " is not supported!  Cannot load {1}", "filename");
            }

            return model;
        }

        public static List<MeshInfo> analyzeModel(Scene model)
        {

            List<MeshInfo> result = new List<MeshInfo>();

            var mat = model.Materials;

            for (int j = 0; j < model.MeshCount; j++)
            {
                MeshInfo mInfo = new MeshInfo();
                var fVertices = new List<float>();
                int[] fIndices = new int[0];

                Assimp.Mesh m = model.Meshes[j];
                Vector3[] positions = new Vector3[m.VertexCount];
                Vector2[] textureCoords = new Vector2[m.VertexCount];
                Vector3[] normals = new Vector3[m.VertexCount];
                Vector3[] tangents = new Vector3[m.VertexCount];

                var min = new Vector3(float.MaxValue);
                var max = new Vector3(float.MinValue);

                for (var i = 0; i < m.VertexCount; i++)
                {
                    Vector3 pos = m.HasVertices ? Util.ToVector3(m.Vertices[i]) : new Vector3();
                    Vector3 t = m.HasTextureCoords(0) ? Util.ToVector3(m.TextureCoordinateChannels[0][i]) : new Vector3();
                    Vector3 normal = m.HasNormals ? Util.ToVector3(m.Normals[i]) : new Vector3();
                    Vector3 tangent = m.HasTangentBasis ? Util.ToVector3(m.Tangents[i]) : new Vector3();

                    /*
                    min = Vector3.Min(min, pos);
                    max = Vector3.Max(max, pos);

                    positions[i] = pos;
                    textureCoords[i] = new Vector2(t.X, -t.Y);
                    normals[i] = normal;
                    tangents[i] = tangent;
                    */

                    fVertices.Add(pos.X);
                    fVertices.Add(pos.Y);
                    fVertices.Add(pos.Z);
                    fVertices.Add(normal.X);
                    fVertices.Add(normal.Y);
                    fVertices.Add(normal.Z);
                    fVertices.Add(t.X);
                    fVertices.Add(t.Y);
                }

                int[] indices = m.GetIndices();
                mInfo.vertices = fVertices.ToArray();
                mInfo.indicate = indices;
                result.Add(mInfo);
            }

            return result;
        }
    }
}
