using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace LetraU
{
    class Game : GameWindow
    {
        private Escenario escenario;
        public Game() : base(500, 700, GraphicsMode.Default, "U en 3D")
        {

            escenario = new Escenario();
            //CargarEscenario();

        }


        /*private void CargarEscenario()
        {
            var caras = Vertice.CrearCaras();

            // Primer objeto U
            var objetoU1 = new Objeto();
            var parteVertical1_U1 = new Parte();
            var parteVertical2_U1 = new Parte();
            var parteHorizontal_U1 = new Parte();

            parteVertical1_U1.Add("cara1", caras["caraInferiorFrontal"]);
            parteVertical1_U1.Add("cara2", caras["caraInferiorTrasera"]);
            parteVertical1_U1.Add("cara3", caras["caraSuperiorFrontal"]);
            parteVertical1_U1.Add("cara4", caras["caraSuperiorTrasera"]);
            parteVertical1_U1.Add("cara5", caras["caraLateralDerechaFrontal"]);
            parteVertical1_U1.Add("cara6", caras["caraLateralIzquierdaFrontal"]);

            parteVertical2_U1.Add("cara7", caras["caraInteriorIzquierda"]);
            parteVertical2_U1.Add("cara8", caras["caraInteriorDerecha"]);
            parteVertical2_U1.Add("cara9", caras["caraSuperiorInternaIzquierda"]);
            parteVertical2_U1.Add("cara10", caras["caraSuperiorInternaDerecha"]);
            parteVertical2_U1.Add("cara11", caras["caraSuperiorIzquierda"]);
            parteVertical2_U1.Add("cara12", caras["caraSuperiorDerecha"]);

            parteHorizontal_U1.Add("cara13", caras["caraTraseraIzquierda"]);
            parteHorizontal_U1.Add("cara14", caras["caraTraseraDerecha"]);
            parteHorizontal_U1.Add("cara15", caras["caraInferiorInternaIzquierda"]);
            parteHorizontal_U1.Add("cara16", caras["caraInferiorInternaDerecha"]);
            parteHorizontal_U1.Add("cara17", caras["caraLateralSuperiorIzquierda"]);
            parteHorizontal_U1.Add("cara18", caras["caraLateralSuperiorDerecha"]);

            objetoU1.Add("objeto1", parteVertical1_U1);
            objetoU1.Add("objeto2", parteVertical2_U1);
            objetoU1.Add("objeto3", parteHorizontal_U1);

            escenario.Add("objetoU1", objetoU1);

            // Segundo objeto U
            var objetoU2 = new Objeto();
            var parteVertical1_U2 = new Parte();
            var parteVertical2_U2 = new Parte();
            var parteHorizontal_U2 = new Parte();

            parteVertical1_U2.Add("cara1", caras["caraInferiorFrontal"]);
            parteVertical1_U2.Add("cara2", caras["caraInferiorTrasera"]);
            parteVertical1_U2.Add("cara3", caras["caraSuperiorFrontal"]);
            parteVertical1_U2.Add("cara4", caras["caraSuperiorTrasera"]);
            parteVertical1_U2.Add("cara5", caras["caraLateralDerechaFrontal"]);
            parteVertical1_U2.Add("cara6", caras["caraLateralIzquierdaFrontal"]);

            parteVertical2_U2.Add("cara7", caras["caraInteriorIzquierda"]);
            parteVertical2_U2.Add("cara8", caras["caraInteriorDerecha"]);
            parteVertical2_U2.Add("cara9", caras["caraSuperiorInternaIzquierda"]);
            parteVertical2_U2.Add("cara10", caras["caraSuperiorInternaDerecha"]);
            parteVertical2_U2.Add("cara11", caras["caraSuperiorIzquierda"]);
            parteVertical2_U2.Add("cara12", caras["caraSuperiorDerecha"]);

            parteHorizontal_U2.Add("cara13", caras["caraTraseraIzquierda"]);
            parteHorizontal_U2.Add("cara14", caras["caraTraseraDerecha"]);
            parteHorizontal_U2.Add("cara15", caras["caraInferiorInternaIzquierda"]);
            parteHorizontal_U2.Add("cara16", caras["caraInferiorInternaDerecha"]);
            parteHorizontal_U2.Add("cara17", caras["caraLateralSuperiorIzquierda"]);
            parteHorizontal_U2.Add("cara18", caras["caraLateralSuperiorDerecha"]);

            objetoU2.Add("objeto1", parteVertical1_U2);
            objetoU2.Add("objeto2", parteVertical2_U2);
            objetoU2.Add("objeto3", parteHorizontal_U2);

            escenario.Add("objetoU2", objetoU2);
            Serializar.GuardarJson(new Dictionary<string, Escenario> { { "escenario", escenario } }, "datos.json");
        }*/


      
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10, 10, -10, 10, -10, 10);

            var escenarios = Serializar.CargarJson("datos.json");
            escenario = escenarios.ContainsKey("escenario") ? escenarios["escenario"] : new Escenario();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
         
            escenario.Get("objetoU1").Draw(new Vertice(0.0f, 0.0f, 0.0f));
            escenario.Get("objetoU2").Draw(new Vertice(5.0f, 5.0f, 5.0f));
            SwapBuffers();
        }
        

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            var teclado = Keyboard.GetState();

            var objetoU1 = escenario.Get("objetoU1");
            Parte parteHorizontal_U1 = objetoU1.Get("objeto1");
            Parte parteVertical1_U1 = objetoU1.Get("objeto2");
            Parte parteVertical2_U1 = objetoU1.Get("objeto3");

            var objetoU2 = escenario.Get("objetoU2");
            Parte parteHorizontal_U2 = objetoU2.Get("objeto1");
            Parte parteVertical1_U2 = objetoU2.Get("objeto2");
            Parte parteVertical2_U2 = objetoU2.Get("objeto3");

            if (teclado.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            // Rotar el escenario
            if (teclado.IsKeyDown(Key.Q))
            {
                escenario.RotarEscenario("y", 1.0f);  // Rotar alrededor del eje Y
            }

            if (teclado.IsKeyDown(Key.W))
            {
                escenario.RotarEscenario("x", 1.0f);  // Rotar alrededor del eje X
            }

            if (teclado.IsKeyDown(Key.E))
            {
                escenario.RotarEscenario("z", 1.0f);  // Rotar alrededor del eje Z
            }
            //////////////////////////////////////////////////////
            // Escalar el escenario
            if (teclado.IsKeyDown(Key.R))
            {
                escenario.ScalarEscenario(1.1f);  // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.T))
            {
                escenario.ScalarEscenario(0.9f);  // Reduce el tamaño
            }

            /////////////////////////////////////////////////////////////
            // Trasladar el escenario
            if (teclado.IsKeyDown(Key.Y))
            {
                escenario.TransladarEscenario(0.1f, 0.0f, 0.0f);  // Mover en el eje X
            }

            if (teclado.IsKeyDown(Key.U))
            {
                escenario.TransladarEscenario(-0.1f, 0.0f, 0.0f);  // Mover en el eje X negativo
            }

            if (teclado.IsKeyDown(Key.I))
            {
                escenario.TransladarEscenario(0.0f, 0.1f, 0.0f);  // Mover en el eje Y positivo 
            }

            if (teclado.IsKeyDown(Key.O))
            {
                escenario.TransladarEscenario(0.0f, -0.1f, 0.0f);  // Mover en el eje Y negativo 
            }
            /////////////////////////////////////////
            // Rotar el Objeto 1
            if (teclado.IsKeyDown(Key.A))
            {
                objetoU1.RotarObjeto("y", 1.0f);  // Rotar alrededor del eje Y
            }

            if (teclado.IsKeyDown(Key.S))
            {
                objetoU1.RotarObjeto("x", 1.0f);  // Rotar alrededor del eje X
            }

            // Rotar el Objeto 2
            if (teclado.IsKeyDown(Key.D))
            {
                objetoU2.RotarObjeto("y", 1.0f);   // Rotar alrededor del eje Z
            }
            if (teclado.IsKeyDown(Key.F))
            {
                objetoU2.RotarObjeto("x", 1.0f);   // Rotar alrededor del eje Z
            }

            // Escalar el objeto1
            if (teclado.IsKeyDown(Key.Left))
            {
                objetoU1.ScalarObjeto(1.1f);  // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.Right))
            {
                objetoU1.ScalarObjeto(0.9f);  // Reduce el tamaño
            }
            // Escalar el objeto2
            if (teclado.IsKeyDown(Key.Up))
            {
                objetoU2.ScalarObjeto(1.1f); // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.Down))
            {
                objetoU2.ScalarObjeto(0.9f);  // Reduce el tamaño
            }

            // Trasladar el objeto1
            if (teclado.IsKeyDown(Key.G))
            {
                objetoU1.TransladarObjeto(0.1f, 0.0f, 0.0f);  // Mover en el eje X
            }

            if (teclado.IsKeyDown(Key.H))
            {
                objetoU1.TransladarObjeto(-0.1f, 0.0f, 0.0f);  // Mover en el eje X negativo
            }

            // Trasladar el objeto2
            if (teclado.IsKeyDown(Key.J))
            {
                objetoU2.TransladarObjeto(0.0f, 0.1f, 0.0f);  // Mover en el eje Y positivo 
            }

            if (teclado.IsKeyDown(Key.K))
            {
                objetoU2.TransladarObjeto(0.0f, -0.1f, 0.0f);  // Mover en el eje Y negativo 
            }

            // Rotar el Parte del ObjetoU1
            if (teclado.IsKeyDown(Key.Z))
            {
                parteVertical1_U1.RotarParte("y", 1.0f);  // Rotar alrededor del eje Y
            }

            if (teclado.IsKeyDown(Key.X))
            {
                parteVertical2_U1.RotarParte("x", 1.0f);  // Rotar alrededor del eje X
            }

            if (teclado.IsKeyDown(Key.C))
            {
                parteHorizontal_U1.RotarParte("z", 1.0f);  // Rotar alrededor del eje Z
            }

            // Rotar el Parte del ObjetoU1
            if (teclado.IsKeyDown(Key.V))
            {
                parteVertical1_U2.RotarParte("y", 1.0f);  // Rotar alrededor del eje Y
            }

            if (teclado.IsKeyDown(Key.B))
            {
                parteVertical2_U2.RotarParte("x", 1.0f);  // Rotar alrededor del eje X
            }

            if (teclado.IsKeyDown(Key.N))
            {
                parteHorizontal_U2.RotarParte("z", 1.0f);  // Rotar alrededor del eje Z
            }

            // Escalar la parte vertical1 del  objeto1
            if (teclado.IsKeyDown(Key.Keypad1))
            {
                parteVertical1_U1.ScalarParte(1.1f);  // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.Keypad2))
            {
                parteVertical1_U1.ScalarParte(0.9f);  // Reduce el tamaño
            }
            // Escalar la parte vertical1 del  objeto1
            if (teclado.IsKeyDown(Key.Keypad4))
            {
                parteVertical2_U1.ScalarParte(1.1f);  // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.Keypad5))
            {
                parteVertical2_U1.ScalarParte(0.9f);  // Reduce el tamaño
            }

            // Escalar la parte horizontal1 del  objeto1
            if (teclado.IsKeyDown(Key.Keypad7))
            {
                parteHorizontal_U1.ScalarParte(1.1f);  // Aumenta el tamaño
            }

            if (teclado.IsKeyDown(Key.Keypad8))
            {
                parteHorizontal_U1.ScalarParte(0.9f);  // Reduce el tamaño
            }


            // Trasladar el escenario
            if (teclado.IsKeyDown(Key.F1))
            {
                parteVertical1_U1.TransladarParte(0.1f, 0.0f, 0.0f);  // Mover en el eje X
            }

            if (teclado.IsKeyDown(Key.F2))
            {
                parteVertical1_U1.TransladarParte(-0.1f, 0.0f, 0.0f);  // Mover en el eje X negativo
            }

            if (teclado.IsKeyDown(Key.F3))
            {
                parteVertical2_U1.TransladarParte(0.0f, 0.1f, 0.0f);  // Mover en el eje Y positivo 
            }

            if (teclado.IsKeyDown(Key.F4))
            {
                parteVertical2_U1.TransladarParte(0.0f, -0.1f, 0.0f);  // Mover en el eje Y negativo 
            }

            if (teclado.IsKeyDown(Key.F5))
            {
                parteHorizontal_U1.TransladarParte(0.0f, 0.1f, 0.0f);  // Mover en el eje Y positivo 
            }

            if (teclado.IsKeyDown(Key.F6))
            {
                parteHorizontal_U1.TransladarParte(0.0f, -0.1f, 0.0f);  // Mover en el eje Y negativo 
            }
        }
    }
}
