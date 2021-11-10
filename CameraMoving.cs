using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Test
{
    class CameraMoving
    {
        Camera cam = new Camera();



        public void CameraMove()
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Left])
            {
                cam.MoveForward();
            }
            if (keyboard[Key.Right])
            {
                cam.MoveBackward();
            }
            if (keyboard[Key.Down])
            {
                cam.MoveLeft();
            }
            if (keyboard[Key.Up])
            {
                cam.MoveRight();
            }
            if (keyboard[Key.Number1])
            {
                cam.MoveUp();
            }
            if (keyboard[Key.Number2])
            {
                cam.MoveDown();
            }
        }

    }
}
