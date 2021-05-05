using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;

namespace EventDraw._3d
{
    public class Camera
    {
        private float _fov = MathHelper.PiOver2;
        private Vector3 _front = -Vector3.UnitZ;
        private float _pitch;
        private float _yaw = -MathHelper.PiOver2;

        private readonly float _cameraSpeed = 0.1f;

        public Camera(Vector3 position, float aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
        }

        public Vector3 Position { get; set; }
        private float AspectRatio { get; }
        public Vector3 Front => _front;
        public Vector3 Up { get; private set; } = Vector3.UnitY;
        public Vector3 Right { get; private set; } = Vector3.UnitX;

        public float Pitch
        {
            get
            {
                return MathHelper.RadiansToDegrees(_pitch);
            }
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get
            {
                return MathHelper.RadiansToDegrees(_yaw);
            }
            set
            {
                _yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Fov
        {
            get
            {
                return MathHelper.RadiansToDegrees(_fov);
            }
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + _front, Up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.01f, 10000f);
        }

        private void UpdateVectors()
        {
            _front.X = (float)Math.Cos(_pitch) * (float)Math.Cos(_yaw);
            _front.Y = (float)Math.Sin(_pitch);
            _front.Z = (float)Math.Cos(_pitch) * (float)Math.Sin(_yaw);

            _front = Vector3.Normalize(_front);

            Right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            Up = Vector3.Normalize(Vector3.Cross(Right, _front));
        }

        public void Forward()
        {
            Position += Front * _cameraSpeed; // Forward
        }

        public void Backwards()
        {
            Position -= Front * _cameraSpeed; // Backwards
        }

        public void RightMove()
        {
            Position += Right * _cameraSpeed;
        }

        public void LeftMove()
        {
            Position -= Right * _cameraSpeed;
        }
    }
}
