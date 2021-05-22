using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace EventDraw._3d
{
    class Wall : Object
    {
        private float height = 300;

        public Wall(float[] vertices, Shader lightingShader, Lamp lamp, Color4 col)
            : base(vertices, lightingShader, lamp, col)
        {
            _opacity = 0.5f;
        }

        public override void SetPosition(float x, float y, float z)
        {
            base.SetPosition(x, y + height / 2, z);
        }

        public override void Show(Camera camera)
        {
            GL.Disable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.DepthMask(false);
            base.Show(camera);
            GL.Disable(EnableCap.Blend);
            GL.DepthMask(true);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
