﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_Test
{
    class Camera
    {


        private Vector3 eye;
        private Vector3 target;
        private Vector3 up_vector;

        private Vector3 eyeNear;
        private Vector3 targetNear;
        private Vector3 up_vectorNear;

        private Vector3 eyeFar;
        private Vector3 targetFar;
        private Vector3 up_vectorFar;


        private const int MOVEMENT_UNIT = 1;

        public Camera()
        {
            eye = new Vector3(10, 20, 35);
            target = new Vector3(0, 0, 0);
            up_vector = new Vector3(0, 3, 0);

            eyeNear = new Vector3(0, 20, 10);
            targetNear = new Vector3(0, 0, 0);
            up_vectorNear = new Vector3(0, 10, 0);

            eyeFar = new Vector3(0, 20, 55);
            targetFar = new Vector3(0, 0, 0);
            up_vectorFar = new Vector3(0, 3, 0);
        }

        public Camera(int _eyeX, int _eyeY, int _eyeZ, int _targetX, int _targetY, int _targetZ, int _upX, int _upY, int _upZ)
        {
            eye = new Vector3(_eyeX, _eyeY, _eyeZ);
            target = new Vector3(_targetX, _targetY, _targetZ);
            up_vector = new Vector3(_upX, _upY, _upZ);
        }

        public Camera(Vector3 _eye, Vector3 _target, Vector3 _up)
        {
            eye = _eye;
            target = _target;
            up_vector = _up;
        }

        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up_vector);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        public void SetCameraNear()
        {
            Matrix4 camera = Matrix4.LookAt(eyeNear, targetNear, up_vectorNear);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        public void SetCameraFar()
        {
            Matrix4 camera = Matrix4.LookAt(eyeFar, targetFar, up_vectorFar);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }


        public void MoveRight()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z - MOVEMENT_UNIT);
            SetCamera();
        }
        public void MoveLeft()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        public void MoveForward()
        {
            eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X - MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveBackward()
        {
            eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X + MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveUp()
        {
            eye = new Vector3(eye.X, eye.Y + MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y + MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        public void MoveDown()
        {
            eye = new Vector3(eye.X, eye.Y - MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y - MOVEMENT_UNIT, target.Z);
            SetCamera();
        }


    }


}
