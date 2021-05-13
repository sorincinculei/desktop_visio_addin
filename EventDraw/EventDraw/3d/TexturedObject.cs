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
    class TexturedObject : BaseObject
    {
        List<Mesh> mMesh = new List<Mesh>();

        private readonly Shader _shader;

        private Vector3 _pos;
        private float _rotX, _rotY, _rotZ;

        private Scene m_model;
        private Vector3 m_sceneMin, m_sceneMax;

        private Vector3 _offset;

        private Vector3 _scale = new Vector3(1, 1, 1);

        private readonly Lamp _lamp;

        public TexturedObject(string path, Shader textureShader, Lamp lamp, string texturePath)
        {
            _lamp = lamp;

            m_model = ObjLoader.LoadObjTextured(path);
            List<MeshInfo> infos = ObjLoader.analyzeModel(m_model);

            foreach (MeshInfo m in infos)
            {
                Material mat = new Material();
                mat.Ambient = convertV(m.ambientC);
                mat.Diffuse = convertV(m.diffuseC);
                mat.Specular = convertV(m.specularC);

                Mesh mesh = new Mesh(m.vertices, m.indicate, textureShader, texturePath, mat);
                mMesh.Add(mesh);
            }

            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _offset = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = textureShader;

            ComputeBoundingBox();
            SetPosition(0.0f, 0.0f, 0.0f);
        }

        public override void Show(Camera camera)
        {
            foreach(Mesh m in mMesh)
            {
                m.Show(camera, _lamp);
            }
        }

        private void ComputeBoundingBox()
        {
            m_sceneMin = new Vector3(1e10f, 1e10f, 1e10f);
            m_sceneMax = new Vector3(-1e10f, -1e10f, -1e10f);
            Matrix4 identity = Matrix4.Identity;

            ComputeBoundingBox(m_model.RootNode, ref m_sceneMin, ref m_sceneMax, ref identity);

            _offset.X = (m_sceneMin.X + m_sceneMax.X) / 2.0f;
            //_offset.Y = (m_sceneMin.Y + m_sceneMax.Y) / 2.0f;
            _offset.Y = m_sceneMin.Y;
            _offset.Z = (m_sceneMin.Z + m_sceneMax.Z) / 2.0f;

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
                        Vector3 tmp = Util.FromVector(mesh.Vertices[i]);
                        Vector3.TransformNormal(ref tmp, ref trafo, out tmp);
                        
                        min.X = Math.Min(min.X, tmp.X);
                        min.Y = Math.Min(min.Y, tmp.Y);
                        min.Z = Math.Min(min.Z, tmp.Z);

                        max.X = Math.Max(max.X, tmp.X);
                        max.Y = Math.Max(max.Y, tmp.Y);
                        max.Z = Math.Max(max.Z, tmp.Z);
                    }
                }
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ComputeBoundingBox(node.Children[i], ref min, ref max, ref trafo);
            }
            trafo = prev;
        }

        public override void Dispose()
        {
            foreach (Mesh m in mMesh)
            {
                m.Dispose();
            }
        }

        public override Vector3 getBoundingBox()
        {
            Vector3 result = new Vector3(Vector3.Zero);
            result.X = m_sceneMax.X - m_sceneMin.X;
            result.Y = m_sceneMax.Y - m_sceneMin.Y;
            result.Z = m_sceneMax.Z - m_sceneMin.Z;

            return result;
        }

        public override void SetPosition(float x, float y, float z)
        {
            _pos.X = x;
            _pos.Y = y;
            _pos.Z = z;

            foreach (Mesh m in mMesh)
            {
                m.SetPositionInSpace(-_offset.X + x, -_offset.Y  +  y, -_offset.Z +  z);
            }
        }

        public override void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            _scale.X = scaleX;
            _scale.Y = scaleY;
            _scale.Z = scaleZ;

            ComputeBoundingBox();

            _offset.X = _offset.X * scaleX;
            _offset.Y = _offset.Y * scaleY;
            _offset.Z = _offset.Z * scaleZ;

            foreach (Mesh m in mMesh)
            {
                m.setScale(scaleX, scaleY, scaleZ);
            }

            SetPosition(_pos.X, _pos.Y, _pos.Z);
        }

        private Vector3 convertV(Color4 c)
        {
            return new Vector3(c.R, c.G, c.B);
        }
    }
}
