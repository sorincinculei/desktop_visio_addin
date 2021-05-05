using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace EventDraw._3d
{
    class TexturedObject
    {
        private readonly float[] _vertices;
        private readonly int _mainObject;
        private readonly int _vertexBufferObject;
        private readonly Shader _shader;

        private Vector3 _pos;
        private float _rotX, _rotY, _rotZ;

        public TexturedObject(string path, Shader textureShader, string texturePath)
        {
            _vertices = ObjLoader.LoadObjTextured(path);

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

            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = textureShader;
        }

        public void Show(Camera camera)
        {
            _shader.SetMatrix4("model",
                Matrix4.CreateRotationX(_rotX) * Matrix4.CreateRotationX(_rotY) * Matrix4.CreateRotationZ(_rotZ) *
                Matrix4.CreateTranslation(_pos));

            _shader.SetMatrix4("view", camera.GetViewMatrix());
            _shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertices.Length / 8);
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

        public void Dispose()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_mainObject);
        }
    }
}
