using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using System.Collections;



//Beleniuc Vitalie 3132B Laboratorul 5
//Aplicatie template scrisa de la 0

//Creați o aplicație care la apăsarea unui clic va genera un obiect ce se
//va deplasa în direcția “jos”. La contactul cu planul Oxz deplasarea
//încetează. Pentru animație veti folosi un contor legat de valoarea de
//update a metodei OnUpdateFrame(). Se va lucra în manieră OOP (pentru
//cameră inclusiv).


namespace OpenTK_Test
{

    class Window : GameWindow
    {
        Shapes shape = new Shapes();
        Desenare controls = new Desenare();
        Camera cam = new Camera();
        CadereCub cade = new CadereCub();
        CameraMoving cam2 = new CameraMoving();




        public Window() : base(900, 700, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            //controls.Controls();
            //controls.fataControls();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Always);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;


            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            cam.SetCamera();


        }



        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            shape.DrawAxe();


            //Creați o aplicație care la apăsarea unui clic va genera un obiect ce se
            //va deplasa în direcția “jos”. La contactul cu planul Oxz deplasarea
            //încetează. Pentru animație veti folosi un contor legat de valoarea de
            //update a metodei OnUpdateFrame(). Se va lucra în manieră OOP (pentru
            //cameră inclusiv).
            cade.Cadere();




            SwapBuffers();

        }



        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            cam2.CameraMove();


            //Modificați aplicația pentru a manipula valorile camerei(permite miș -
            //care și repoziționare la 2 locații predefinite, “aproape” și “departe”.


            if (keyboard[Key.Q])
            {
                cam.SetCameraNear();
            }

            if (keyboard[Key.E])
            {
                cam.SetCameraFar();
            }

            if (keyboard[Key.W])
            {
                cam.SetCamera();
            }

            if (keyboard[Key.Escape])
            {
                Exit();
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButton.Left)
            {
                cade.Generare();
            }
        }





        static void Main(string[] args)
        {
            using (Window example = new Window())
            {
                example.Run(0.0, 60.0);
            }
        }
    }
}