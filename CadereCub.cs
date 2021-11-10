using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_Test
{


    //Creați o aplicație care la apăsarea unui clic va genera un obiect ce se
    //va deplasa în direcția “jos”. La contactul cu planul Oxz deplasarea
    //încetează. Pentru animație veti folosi un contor legat de valoarea de
    //update a metodei OnUpdateFrame(). Se va lucra în manieră OOP (pentru
    //cameră inclusiv).

    class CadereCub
    {

        Shapes shape = new Shapes();
        Random rand = new Random();
        private List<Vector3> coordsList = new List<Vector3>();


        bool drawShape = false;
        float x, y, z;
        int i = 0;
        int limit = 0;
        bool collision = false;


        public void Check(int limit1)
        {
            if (limit1 >= y)
            {
                drawShape = false;
                limit = 0;
                i = 0;
                collision = true;
            }
        }

        public void Cadere()

        {
            if (drawShape == true)
            {
                GL.PushMatrix();
                GL.Translate(0, i--, 0);
                Check(limit);
                limit++;
                GL.Translate(x, y, z);
                shape.DrawCub1();
                GL.PopMatrix();
            }

            if (collision == true)
            {
                coordsList.Add(new Vector3(x, y, z));
                collision = false;
            }

            foreach (Vector3 v in coordsList)
            {
                GL.PushMatrix();
                GL.Translate(v.X, 0, v.Z);
                shape.DrawCub1();
                GL.PopMatrix();
            }
        }



        public void Generare()
        {
            x = rand.Next(-20, 20);
            y = rand.Next(0, 20);
            z = rand.Next(-20, 20);


            shape.Meniu();
            Console.WriteLine("Obiect generat la:" + x + " " + y + " " + z);
            drawShape = true;
        }

    }
}
