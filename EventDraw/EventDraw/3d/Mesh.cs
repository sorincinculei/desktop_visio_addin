using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace EventDraw._3d
{
    class Mesh
    {
        private readonly float[] _vertices;
        private readonly int[] _indices;

        private readonly int _mainObject;
        private readonly int _vertexBufferObject;
        private readonly int _elementBufferObject;

        private readonly Shader _shader;

        private Vector3[] positions = new Vector3[0];
        private Vector2[] texCoords = new Vector2[0];
        private Vector3[] normals = new Vector3[0];
        private int[] indices = new int[0];

        private Vector3 _pos;
        private float _rotX, _rotY, _rotZ;
        private Vector3 _scale = new Vector3(1, 1, 1);
        private readonly Material _mat;

        public Mesh(float[] vertices, int[] indices, Shader textureShader, string texturePath, Material mat)
        {
            _vertices = vertices;
            _indices = indices;
            _mat = mat;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices,
                BufferUsageHint.StaticDraw);

            _mainObject = GL.GenVertexArray();
            GL.BindVertexArray(_mainObject);

            var positionLocation = textureShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normalLocation = textureShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float),
                3 * sizeof(float));

            var textureLocation = textureShader.GetAttribLocation("aTexture");
            GL.EnableVertexAttribArray(textureLocation);
            GL.VertexAttribPointer(textureLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float),
                6 * sizeof(float));

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(int), _indices, BufferUsageHint.StaticDraw);

            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = textureShader;
        }

        public void Show(Camera camera, Lamp _lamp)
        {
            GL.BindVertexArray(_mainObject);
            _shader.Use();

            _shader.SetMatrix4("model",
            Matrix4.CreateRotationX(_rotX) * Matrix4.CreateRotationY(_rotY) * Matrix4.CreateRotationZ(_rotZ) * Matrix4.CreateScale(_scale) * 
            Matrix4.CreateTranslation(_pos));

            _shader.SetMatrix4("view", camera.GetViewMatrix());
            _shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            _shader.SetVector3("viewPos", camera.Position);

            _shader.SetVector3("material.ambient", _mat.Ambient);
            _shader.SetVector3("material.diffuse", _mat.Diffuse);
            _shader.SetVector3("material.specular", _mat.Specular);
            _shader.SetFloat("material.shininess", _mat.Shininess);

            Vector3 ambientColor = new Vector3(1.0f) * new Vector3(0.4f);
            Vector3 diffuseColor = new Vector3(1.0f) * new Vector3(0.8f);
            Vector3 specularColor = new Vector3(1.0f) * new Vector3(0.5f);

            _shader.SetVector3("light.position", _lamp.Pos);
            _shader.SetVector3("light.ambient", ambientColor);
            _shader.SetVector3("light.diffuse", diffuseColor);
            _shader.SetVector3("light.specular", specularColor);

            _shader.SetFloat("opacity", _mat.Opacity);

            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void SetRotationX(float angle)
        {
            _rotX = angle;
        }

        public void SetRotationY(float angle)
        {
            _rotY = angle;
        }

        public void SetRotationZ(float angle)
        {
            _rotZ = angle;
        }

        public void SetPositionInSpace(float x, float y, float z)
        {
            _pos = new Vector3(x, y, z);
        }

        public void setScale(float scaleX, float scaleY, float scaleZ)
        {
            _scale.X = scaleX;
            _scale.Y = scaleY;
            _scale.Z = scaleZ;
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_mainObject);
        }
    }
}
