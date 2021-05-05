using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;

namespace EventDraw._3d
{
    public class Lamp
    {
        private readonly int _mainObject;
        private readonly int _vertexBufferObject;
        private readonly float[] _vertices;
        public readonly Vector3 LightColor;
        public readonly Vector3 Pos;

        public Lamp(Vector3 pos, Vector3 lightColor, Shader lampShader, float radius)
        {
            Pos = pos;
            LightColor = lightColor;
        }

        public void Show(Camera camera, Shader lampShader)
        {

        }
    }
}
