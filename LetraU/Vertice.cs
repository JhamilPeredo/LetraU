using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    class Vertice
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vertice(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public static void DibujarU(Posicion posicion)
        {
            Vertice[] vertices = new Vertice[]
            {
                 new Vertice(-2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.5f, 0.5f),
                new Vertice(-2.0f, -1.5f, 0.5f),

                new Vertice(-2.0f, -1.0f, -0.5f),
                new Vertice(2.0f, -1.0f, -0.5f),
                new Vertice(2.0f, -1.5f, -0.5f),
                new Vertice(-2.0f, -1.5f, -0.5f),

                new Vertice(-2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.5f, 0.5f),
                new Vertice(-2.0f, -1.5f, 0.5f),

                new Vertice(-2.0f, -1.5f, 0.5f),
                new Vertice(2.0f, -1.5f, 0.5f),
                new Vertice(2.0f, -1.5f, -0.5f),
                new Vertice(-2.0f, -1.5f, -0.5f),

                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.5f, 0.5f),
                new Vertice(2.0f, -1.5f, -0.5f),
                new Vertice(2.0f, -1.0f, -0.5f),

                new Vertice(-2.0f, -1.0f, 0.5f),
                new Vertice(-2.0f, -1.5f, 0.5f),
                new Vertice(-2.0f, -1.5f, -0.5f),
                new Vertice(-2.0f, -1.0f, -0.5f),

                new Vertice(-2.0f, 1.5f, 0.5f),
                new Vertice(-1.5f, 1.5f, 0.5f),
                new Vertice(-1.5f, -1.0f, 0.5f),
                new Vertice(-2.0f, -1.0f, 0.5f),

                new Vertice(-2.0f, 1.5f, -0.5f),
                new Vertice(-1.5f, 1.5f, -0.5f),
                new Vertice(-1.5f, -1.0f, -0.5f),
                new Vertice(-2.0f, -1.0f, -0.5f),

                new Vertice(-2.0f, 1.5f, 0.5f),
                new Vertice(-1.5f, 1.5f, 0.5f),
                new Vertice(-1.5f, 1.5f, -0.5f),
                new Vertice(-2.0f, 1.5f, -0.5f),

                new Vertice(-2.0f, -1.0f, 0.5f),
                new Vertice(-1.5f, -1.0f, 0.5f),
                new Vertice(-1.5f, -1.0f, -0.5f),
                new Vertice(-2.0f, -1.0f, -0.5f),

                new Vertice(-1.5f, 1.5f, 0.5f),
                new Vertice(-1.5f, -1.0f, 0.5f),
                new Vertice(-1.5f, -1.0f, -0.5f),
                new Vertice(-1.5f, 1.5f, -0.5f),

                new Vertice(-2.0f, 1.5f, 0.5f),
                new Vertice(-2.0f, -1.0f, 0.5f),
                new Vertice(-2.0f, -1.0f, -0.5f),
                new Vertice(-2.0f, 1.5f, -0.5f),


                new Vertice(1.5f, 1.5f, 0.5f),
                new Vertice (2.0f, 1.5f, 0.5f),
                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(1.5f, -1.0f, 0.5f),

                new Vertice(1.5f, 1.5f, -0.5f),
                new Vertice(2.0f, 1.5f, -0.5f),
                new Vertice(2.0f, -1.0f, -0.5f),
                new Vertice(1.5f, -1.0f, -0.5f),

                new Vertice(1.5f, 1.5f, 0.5f),
                new Vertice(2.0f, 1.5f, 0.5f),
                new Vertice(2.0f, 1.5f, -0.5f),
                new Vertice(1.5f, 1.5f, -0.5f),

                new Vertice(1.5f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.0f, -0.5f),
                new Vertice(1.5f, -1.0f, -0.5f),

                new Vertice(2.0f, 1.5f, 0.5f),
                new Vertice(2.0f, -1.0f, 0.5f),
                new Vertice(2.0f, -1.0f, -0.5f),
                new Vertice(2.0f, 1.5f, -0.5f),

                new Vertice(1.5f, 1.5f, 0.5f),
                new Vertice(1.5f, -1.0f, 0.5f),
                new Vertice(1.5f, -1.0f, -0.5f),
                new Vertice(1.5f, 1.5f, -0.5f),
            };

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(0.0f, 0.0f, 1.0f);
            foreach (var vertice in vertices)
            {
                GL.Vertex3(vertice.X + posicion.X, vertice.Y + posicion.Y, vertice.Z + posicion.Z);
            }
            GL.End();
        }

    }

}
