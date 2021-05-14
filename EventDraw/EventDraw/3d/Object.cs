using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace EventDraw._3d
{
    class Object : BaseObject
    { 
        private readonly float[] _vertices;
        private readonly int _mainObject;
        private readonly int _vertexBufferObject;
        private readonly Shader _shader;

        private readonly Color4 _color;
        private readonly Lamp _lamp;

        private Vector3 _pos;
        private float _rotX, _rotY, _rotZ;
        private float _scale = 1.0f;

        public Object(string path, Shader lightingShader, Lamp lamp, Color4 col)
        {
            _vertices = EventDraw.ObjLoader.Load(path);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices,
                BufferUsageHint.StaticDraw);

            _mainObject = GL.GenVertexArray();
            GL.BindVertexArray(_mainObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            var positionLocation = lightingShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

            var normalLocation = lightingShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float),
                3 * sizeof(float));

            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = lightingShader;
            _lamp = lamp;
            _color = col;

            SetRotationX(0.5f);
            SetRotationY(0.5f);
            SetRotationZ(0.5f);
            SetPosition(0.0f, 0.1f, 0.0f);
        }

        public Object(float[] vertices, Shader lightingShader, Lamp lamp, Color4 col)
        {
            _vertices = vertices;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices,
                BufferUsageHint.StaticDraw);

            _mainObject = GL.GenVertexArray();
            GL.BindVertexArray(_mainObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            var positionLocation = lightingShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

            var normalLocation = lightingShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float),
                3 * sizeof(float));
            _rotX = 0.0f;
            _rotY = 0.0f;
            _rotZ = 0.0f;
            _pos = new Vector3(0.0f, 0.0f, 0.0f);
            _shader = lightingShader;
            _lamp = lamp;
            _color = col;

            // SetRotationX((float) Math.PI / 2);
            // SetRotationY(0.5f);
            // SetRotationZ(0.5f);
            // SetPosition(1.0f, 0.0f, 0.0f);
        }

        public override void Show(Camera camera)
        {
            GL.BindVertexArray(_mainObject);
            _shader.Use();

            _shader.SetMatrix4("model",
                    Matrix4.CreateScale(_scale) * Matrix4.CreateRotationX(_rotX) * Matrix4.CreateRotationX(_rotY) *
                    Matrix4.CreateRotationZ(_rotZ) * Matrix4.CreateTranslation(_pos));
            _shader.SetMatrix4("view", camera.GetViewMatrix());
            _shader.SetMatrix4("projection", camera.GetProjectionMatrix());
            
            _shader.SetVector3("objectColor", new Vector3(_color.R, _color.G, _color.B));
            _shader.SetVector3("lightColor", _lamp.LightColor);
            _shader.SetVector3("lightPos", _lamp.Pos);

            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertices.Length / 6);
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

        public override void SetPosition(float x, float y, float z)
        {
            _pos = new Vector3(x, y, z);
        }

        public override void SetScale(float x, float y, float z)
        {

        }

        public override void SetRotate(float x, float y, float z)
        {
            _rotX = x;
            _rotY = y;
            _rotZ = z;
        }

        public override Vector3 getBoundingBox()
        {
            return new Vector3(1, 1, 1);
        }

        public override void Dispose()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_mainObject);
        }

    }
}
