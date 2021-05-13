using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw._3d
{
    abstract class BaseObject
    {
        abstract public void Show(Camera camera);
        abstract public void Dispose();
        abstract public void SetPosition(float x, float y, float z);
        abstract public void SetScale(float x, float y, float z);
        abstract public Vector3 getBoundingBox();
    }
}
