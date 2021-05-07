using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace EventDraw._3d
{
    class InputHandler
    {
        public delegate void KeyPressed(Enum flags);
        public delegate void MousePressed(int x, int y);
        public delegate void MouseWheelMoved(int delta);
        public delegate void MouseMoved(int x, int y);
        public delegate void FileDropped(string file);

        public readonly Dictionary<MouseButtons, MousePressed> mouseDownListeners;
        public readonly Dictionary<MouseButtons, MousePressed> mouseUpListeners;


        public readonly Dictionary<Keys, KeyPressed> keyDownListeners;
        public readonly Dictionary<Keys, KeyPressed> keyUpListeners;

        public event KeyPressed keypressed;
        public event MouseWheelMoved mouseWheelMoved;
        public event MouseMoved mouseMoved;

        public InputHandler(OpenTK.GLControl glControl)
        {
            glControl.KeyDown += KeyDown;
            glControl.KeyUp += KeyUp;
            glControl.MouseDown += MouseDown;
            glControl.MouseUp += MouseUp;
            glControl.MouseMove += MouseMove;
            glControl.MouseWheel += MouseWheel;

            mouseDownListeners = new Dictionary<MouseButtons, MousePressed>();
            mouseUpListeners = new Dictionary<MouseButtons, MousePressed>();

            keyDownListeners = new Dictionary<Keys, KeyPressed>();
            keyUpListeners = new Dictionary<Keys, KeyPressed>();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (keyDownListeners.ContainsKey(e.KeyCode))
            {
                keyDownListeners[e.KeyCode].Invoke(e.Modifiers);
            }

            e.Handled = true;
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (keyUpListeners.ContainsKey(e.KeyCode))
            {
                keyUpListeners[e.KeyCode].Invoke(e.Modifiers);
            }

            e.Handled = true;
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

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoved.GetInvocationList().Length != 0)
            {
                mouseMoved.Invoke(e.X, e.Y);
            }
        }

        private void MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseWheelMoved.GetInvocationList().Length != 0)
            {
                mouseWheelMoved.Invoke(e.Delta);
            }
        }
    }
}