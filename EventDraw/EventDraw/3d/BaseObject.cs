using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw._3d
{
    abstract class BaseObject
    {
        private float _baseElevation;

        protected float _rotX;
        protected float _rotY;
        protected float _rotZ;

        protected Vector3 _pos;
        
        public BaseObject()
        {
            Elevation = 0f;
        }

        public float Elevation
        {
            get
            {
                return _baseElevation;
            }

            set
            {
                _baseElevation = value;
            }
        }

        abstract public void Show(Camera camera);
        abstract public void Dispose();

        abstract public void SetPosition(float x, float y, float z);
        abstract public void SetScale(float x, float y, float z);
        abstract public void SetRotate(float x, float y, float z);
        
        abstract public Vector3 getBoundingBox();
        abstract public BaseObject Clone(Shader textureShader, Lamp lamp, string texturePath);
    }
}
