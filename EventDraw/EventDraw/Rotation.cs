using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw
{
    public class Rotation
    {
        public float angle;
        public Vector3 axis;

        public Rotation()
        : this(0, new Vector3(0, 0, 0))
        { }

        public Rotation(float angle, float x, float y, float z)
        : this(angle, new Vector3(x, y, z))
        { }

        public Rotation(float angle, Vector3 axis)
        {
            this.angle = angle;
            this.axis = axis;
        }
    }
}
