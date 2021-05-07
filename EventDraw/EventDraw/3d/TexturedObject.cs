using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Assimp;

namespace EventDraw._3d
{
    class TexturedObject
    {
        List<Mesh> mMesh = new List<Mesh>();

        private readonly Shader _shader;

        private Vector3 _pos;
        private float _rotX, _rotY, _rotZ;

        private Scene m_model;
        private Vector3 m_sceneMin, m_sceneMax;

        public TexturedObject(string path, Shader textureShader, string texturePath)
        {
            m_model = ObjLoader.LoadObjTextured(path);
            List<MeshInfo> infos = ObjLoader.analyzeModel(m_model);

            foreach (MeshInfo m in infos)
            {
                Mesh mesh = new Mesh(m.vertices, m.indicate, textureShader, texturePath);
                mMesh.Add(mesh);
            }

            ComputeBoundingBox();

            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = textureShader;
        }

        public void Show(Camera camera)
        {
            foreach(Mesh m in mMesh)
            {
                m.Show(camera);
            }
        }

        private void ComputeBoundingBox()
        {
            m_sceneMin = new Vector3(1e10f, 1e10f, 1e10f);
            m_sceneMax = new Vector3(-1e10f, -1e10f, -1e10f);
            Matrix4 identity = Matrix4.Identity;

            ComputeBoundingBox(m_model.RootNode, ref m_sceneMin, ref m_sceneMax, ref identity);
            
            /*
            m_sceneCenter.X = (m_sceneMin.X + m_sceneMax.X) / 2.0f;
            m_sceneCenter.Y = (m_sceneMin.Y + m_sceneMax.Y) / 2.0f;
            m_sceneCenter.Z = (m_sceneMin.Z + m_sceneMax.Z) / 2.0f;
            */
        }

        private void ComputeBoundingBox(Node node, ref Vector3 min, ref Vector3 max, ref Matrix4 trafo)
        {
            Matrix4 prev = trafo;
            trafo = Matrix4.Mult(prev, Util.FromMatrix(node.Transform));

            if (node.HasMeshes)
            {
                foreach (int index in node.MeshIndices)
                {
                    Assimp.Mesh mesh = m_model.Meshes[index];
                    for (int i = 0; i < mesh.VertexCount; i++)
                    {
                        /*
                        Vector3 tmp = Util.FromVector(mesh.Vertices[i]);
                        //Vector3.Transform(ref tmp, ref trafo, out tmp);
                        min.X = Math.Min(min.X, tmp.X);
                        min.Y = Math.Min(min.Y, tmp.Y);
                        min.Z = Math.Min(min.Z, tmp.Z);

                        max.X = Math.Max(max.X, tmp.X);
                        max.Y = Math.Max(max.Y, tmp.Y);
                        max.Z = Math.Max(max.Z, tmp.Z);
                        */
                    }
                }
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ComputeBoundingBox(node.Children[i], ref min, ref max, ref trafo);
            }
            trafo = prev;
        }

        public void Dispose()
        {
            foreach (Mesh m in mMesh)
            {
                m.Dispose();
            }
        }
    }
}
