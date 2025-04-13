using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{
    class Game : GameWindow
    {
        private Escenario escenario;
        private float rotacionX = 0.0f;
        private float rotacionY = 0.0f;

        public Game() : base(500, 700, GraphicsMode.Default, "U en 3D")
        {

            escenario = new Escenario();
            CargarEscenario("datosT.json");

        }

        private void CargarEscenario(string filePath)
        {
            var caras = Serializar.CargarJson(filePath);

            var objetoT = new Objeto();
            var parteVertical1 = new Parte();
            var parteVertical2 = new Parte();
            var parteHorizontal = new Parte();


            parteVertical1.Add("cara1", caras["caraInferiorFrontal"]);
            parteVertical1.Add("cara2", caras["caraInferiorTrasera"]);
            parteVertical1.Add("cara3", caras["caraSuperiorFrontal"]);
            parteVertical1.Add("cara4", caras["caraSuperiorTrasera"]);
            parteVertical1.Add("cara5", caras["caraLateralDerechaFrontal"]);
            parteVertical1.Add("cara6", caras["caraLateralIzquierdaFrontal"]);

            // Parte Vertical (la parte del palito del "T")

            parteVertical2.Add("cara7", caras["caraInteriorIzquierda"]);
            parteVertical2.Add("cara8", caras["caraInteriorDerecha"]);
            parteVertical2.Add("cara9", caras["caraSuperiorInternaIzquierda"]);
            parteVertical2.Add("cara10", caras["caraSuperiorInternaDerecha"]);
            parteVertical2.Add("cara11", caras["caraSuperiorIzquierda"]);
            parteVertical2.Add("cara12", caras["caraSuperiorDerecha"]);

            // Conexiones entre ambas partes (costados)

            parteHorizontal.Add("cara13", caras["caraTraseraIzquierda"]);
            parteHorizontal.Add("cara14", caras["caraTraseraDerecha"]);
            parteHorizontal.Add("cara15", caras["caraInferiorInternaIzquierda"]);
            parteHorizontal.Add("cara16", caras["caraInferiorInternaDerecha"]);
            parteHorizontal.Add("cara17", caras["caraLateralSuperiorIzquierda"]);
            parteHorizontal.Add("cara18", caras["caraLateralSuperiorDerecha"]);

            objetoT.Add("objeto1", parteVertical1);
            objetoT.Add("objeto2", parteVertical2);
            objetoT.Add("objeto3", parteHorizontal);

            escenario.Add("escenario1", objetoT);
        }

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


            escenario.Draw();

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
