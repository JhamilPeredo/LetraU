using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{
    class Game : GameWindow
    {
        private float rotacionX = 0.0f;
        private float rotacionY = 0.0f;

        public Game() : base(500, 700, GraphicsMode.Default, "U en 3D") { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10, 10, -10, 10, -10, 10);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(rotacionX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(rotacionY, 0.0f, 1.0f, 0.0f);


            Posicion[] posiciones = new Posicion[]
           {
                new Posicion(0f, 0f, 0f),      // Centro
                new Posicion(6f, 0f, 0f),      // A la derecha
                new Posicion(-6f, 0f, 0f),     // A la izquierda
                new Posicion(0f, 6f, 0f),      // Arriba
                new Posicion(0f, -6f, 0f)      // Abajo
           };

            foreach (var posicion in posiciones)
            {
                Vertice.DibujarU(posicion);
            }

            SwapBuffers();
        }
        

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            var teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (teclado.IsKeyDown(Key.Left))
            {
                rotacionY -= 2.0f;
            }
            if (teclado.IsKeyDown(Key.Right))
            {
                rotacionY += 2.0f;
            }
            if (teclado.IsKeyDown(Key.Up))
            {
                rotacionX -= 2.0f;
            }
            if (teclado.IsKeyDown(Key.Down))
            {
                rotacionX += 2.0f;
            }
        }
    }
}
