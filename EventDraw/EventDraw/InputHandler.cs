using System;
using System.Collections.Generic;
using OpenTK;
using System.Windows.Forms;

namespace EventDraw
{
    public class InputHandler
    {
        public delegate void KeyPressed(Enum flags);
        public delegate void MousePressed(int x, int y);
        public delegate void MouseWheelMoved(int delta);
        public delegate void MouseMoved(int x, int y);
        public delegate void FileDropped(string file);

        public readonly Dictionary<MouseButtons, MousePressed> mouseDownListeners;
        public readonly Dictionary<MouseButtons, MousePressed> mouseUpListeners;

        public event MouseWheelMoved mouseWheelMoved;
        public event MouseMoved mouseMoved;

        public InputHandler(OpenTK.GLControl glControl)
        {
            glControl.MouseDown += MouseDown;
            glControl.MouseUp += MouseUp;
            glControl.MouseWheel += MouseWheel;
            glControl.MouseMove += MouseMove;

            glControl.DragDrop += DragDrop;

            mouseDownListeners = new Dictionary<MouseButtons, MousePressed>();
            mouseUpListeners = new Dictionary<MouseButtons, MousePressed>();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDownListeners.ContainsKey(e.Button))
            {
                mouseDownListeners[e.Button].Invoke(e.X, e.Y);
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseUpListeners.ContainsKey(e.Button))
            {
                mouseUpListeners[e.Button].Invoke(e.X, e.Y);
            }
        }

        private void MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseWheelMoved.GetInvocationList().Length != 0)
            {
                mouseWheelMoved.Invoke(e.Delta);
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoved.GetInvocationList().Length != 0)
            {
                mouseMoved.Invoke(e.X, e.Y);
            }
        }

        private void DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
