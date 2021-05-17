using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using static EventDraw._3d.Shaders;

namespace EventDraw._3d
{
    public class Engine
    {
        private readonly List<Object> _mainObjects = new List<Object>();
        private readonly List<BaseObject> _mainTexturedObjects = new List<BaseObject>();

        public Camera _camera;
        private Shader _lightingShader, _lampShader, _textureShader;
        private Lamp _mainLamp;

        public Engine()
        {
            onLoad();
            CreateMainLight(new Vector3(0f, 50f, 0f), new Vector3(1.0f, 1.0f, 1.0f));
            // CreatePlane(0.1f, 0.2f, 0.1f, 0.4f, 0.9f, 0.1f, 0.3f, 0.5f, 1.0f, 0.1f, 0.8f, 0.2f,new Color4(0.2f, 0.0f, 0.0f, 0.9f) );

            //CreateCube(new Color4(1.0f, 0.0f, 0.0f, 1.0f), 3.0f, 2.0f, 1.0f);
            
            //string sampleFileName = @"\\3DVG_Man_Colour.X";
            //string samplefilePath = Globals.ThisAddIn.RootPath + @"\Custom" + sampleFileName;
            //OpenObj(samplefilePath, new Color4(1.0f, 1.0f, 1.0f, 1.0f));
            //OpenTexturedObj(samplefilePath, samplefilePath);
        }

        protected void onLoad()
        {
            _lightingShader = new Shader(ShaderVert, LightingFrag);
            _lampShader = new Shader(ShaderVert, ShaderFrag);
            _textureShader = new Shader(TextureVert, TextureFrag);

            _lightingShader.Use();
            _lampShader.Use();
            _textureShader.Use();

            _camera = new Camera(Vector3.UnitZ * 100, 100 / (float) 100);
        }

        protected void OnUnload()
        {
            foreach (var obj in _mainObjects) obj.Dispose();
            foreach (var obj in _mainTexturedObjects) obj.Dispose();
        }

        public void Render3DObjects()
        {
            foreach (var obj in _mainObjects) obj.Show(_camera);
            foreach (var obj in _mainTexturedObjects) obj.Show(_camera);
        }

        public void Clear()
        {
            foreach (var obj in _mainObjects) obj.Dispose();
            foreach (var obj in _mainTexturedObjects) obj.Dispose();

            _mainObjects.Clear();
            _mainTexturedObjects.Clear();
        }

        public void RenderLight()
        {

        }

        public void CreateMainLight(Vector3 pos, Vector3 color)
        {
            _mainLamp = new Lamp(pos, color, _lampShader, 1);
        }

        public int CreatePlane(float x1, float y1, float z1,
            float x2, float y2, float z2,
            float x3, float y3, float z3,
            float x4, float y4, float z4, Color4 color)
        {
            var l1 = new Vector3(x2 - x1, y2 - y1, z2 - z1);
            var l2 = new Vector3(x3 - x1, y3 - y1, z3 - z1);
            var normal = Vector3.Cross(l2, l1);

            float[] vertices =
            {
                x1, y1, z1, normal.X, normal.Y, normal.Z,
                x3, y3, z3, normal.X, normal.Y, normal.Z,
                x2, y2, z2, normal.X, normal.Y, normal.Z,

                x1, y1, z1, normal.X, normal.Y, normal.Z,
                x3, y3, z3, normal.X, normal.Y, normal.Z,
                x4, y4, z4, normal.X, normal.Y, normal.Z
            };
            _mainObjects.Add(new Object(vertices, _lightingShader, _mainLamp, color));
            return _mainObjects.Count - 1;
        }

        public int CreateCube(Color4 color, float width, float height, float depth)
        {
            var cubeVertex = CreateRectangularPrismVertices(width, height, depth);
            _mainTexturedObjects.Add(new Object(cubeVertex, _lightingShader, _mainLamp, color));
            return _mainTexturedObjects.Count - 1;
        }

        public void OpenObj(string obj, Color4 color)
        {
            _mainObjects.Add(new Object(obj, _lightingShader, _mainLamp, color));
        }

        public int OpenTexturedObj(string obj, string texture)
        {
            _mainTexturedObjects.Add(new TexturedObject(obj, _textureShader, _mainLamp, texture));
            return _mainTexturedObjects.Count - 1;
        }

        public void setPostiion(float x, float y, float z, int handle)
        {
            _mainTexturedObjects[handle].SetPosition(x, y, z);
        }

        public void setRotate(float x, float y, float z, int handle)
        {
            _mainTexturedObjects[handle].SetRotate(x, y, z);
        }

        public Vector3 getBoundingBox(int handle)
        {
            return _mainTexturedObjects[handle].getBoundingBox();
        }

        public void setScale(float scaleX, float scaleY, float scaleZ, int handle)
        {
            _mainTexturedObjects[handle].SetScale(scaleX, scaleY, scaleZ);
        }

        public void showAxis()
        {

        }

        public void Destory()
        {
            OnUnload();
        }

        private static float[] CreateRectangularPrismVertices(float width, float height, float depth)
        {
            var w = width / 2;
            var h = height / 2;
            var d = depth / 2;
            var vertices = new List<float>();

            float[] v =
            {
                -w, -h, -d,
                w, -h, -d,
                w, -h, d,
                -w, -h, d,
                -w, h, -d,
                w, h, -d,
                w, h, d,
                -w, h, d
            };

            int[] f =
            {
                //Front
                0, 5, 4,
                0, 1, 5,
                //Right
                1, 6, 5,
                1, 2, 6,
                //Back
                2, 7, 6,
                2, 3, 7,
                //Left
                3, 4, 7,
                3, 0, 4,
                //Bottom
                3, 1, 0,
                3, 2, 1,
                //Top
                4, 6, 7,
                4, 5, 6
            };

            for (var i = 0; i < f.Length; i += 3)
            {
                var v01 = new Vector3(v[f[i] * 3], v[f[i] * 3 + 1], v[f[i] * 3 + 2]);
                var v02 = new Vector3(v[f[i + 1] * 3], v[f[i + 1] * 3 + 1], v[f[i + 1] * 3 + 2]);
                var x = v[f[i + 2] * 3];
                var y = v[f[i + 2] * 3 + 1];
                var z = v[f[i + 2] * 3 + 2];
                var v03 = new Vector3(x, y, z);

                var l1 = v02 - v01;
                var l2 = v03 - v01;

                var n = Vector3.Cross(l1, l2);
                n.Normalize();
                vertices.Add(v01.X);
                vertices.Add(v01.Y);
                vertices.Add(v01.Z);
                vertices.Add(n.X);
                vertices.Add(n.Y);
                vertices.Add(n.Z);
                vertices.Add(v02.X);
                vertices.Add(v02.Y);
                vertices.Add(v02.Z);
                vertices.Add(n.X);
                vertices.Add(n.Y);
                vertices.Add(n.Z);
                vertices.Add(v03.X);
                vertices.Add(v03.Y);
                vertices.Add(v03.Z);
                vertices.Add(n.X);
                vertices.Add(n.Y);
                vertices.Add(n.Z);
            }

            return vertices.ToArray();
        }
    }
}
