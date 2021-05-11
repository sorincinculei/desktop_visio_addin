using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace EventDraw._3d
{
    class Material
    {
        private Vector3 _ambient;
        private Vector3 _diffuse;
        private Vector3 _specular;
        private float _shininess;

        public Material()
        {
            Ambient = new Vector3(1.0f, 0.5f, 0.31f);
            Diffuse = new Vector3(1.0f, 0.5f, 0.31f);
            Specular = new Vector3(0.5f, 0.5f, 0.5f);
            Shininess = 32.0f;
        }

        public Material(Vector3 ambient, Vector3 diffuse, Vector3 specular, float shiniess)
        {
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            Shininess = shiniess;
        }

        public Vector3 Ambient
        {
            get
            {
                return _ambient;
            }
            set
            {
                _ambient = value;
            }
        }

        public Vector3 Diffuse
        {
            get
            {
                return _diffuse;
            }
            set
            {
                _diffuse = value;
            }
        }

        public Vector3 Specular
        {
            get
            {
                return _specular;
            }
            set
            {
                _specular = value;
            }
        }

        public float Shininess
        {
            get
            {
                return _shininess;
            }
            set
            {
                _shininess = value;
            }
        }
    }
}
