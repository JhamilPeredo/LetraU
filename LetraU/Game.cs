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
        private Libreto libreto;
        private Animacion animacion;

        // Variables para la posición y velocidad del auto
        private float posX = 0f;
        private float velocidadX = 1f; // unidades por segundo

        public Game() : base(500, 700, GraphicsMode.Default, "U en 3D")
        {

            escenario = new Escenario();
            libreto = new Libreto();
            animacion = new Animacion();
            CargarEscenario();
            CargarEscenario2(); 
        }
        private void CargarEscenario()
        {
            var caras = Vertice.CrearCarasAuto();

           
            var objetoAuto = new Objeto();

   
            var parteCuerpo = new Parte();
            parteCuerpo.Add("cara1", caras["cuerpoFrontal"]);
            parteCuerpo.Add("cara2", caras["cuerpoTrasero"]);
            parteCuerpo.Add("cara3", caras["cuerpoSuperior"]);
            parteCuerpo.Add("cara4", caras["cuerpoInferior"]);
            parteCuerpo.Add("cara5", caras["cuerpoIzquierdo"]);
            parteCuerpo.Add("cara6", caras["cuerpoDerecho"]);

          
            var parteTecho = new Parte();
            parteTecho.Add("cara7", caras["techoFrontal"]);
            parteTecho.Add("cara8", caras["techoTrasero"]);
            parteTecho.Add("cara9", caras["techoIzquierdo"]);
            parteTecho.Add("cara10", caras["techoDerecho"]);

         
            var parteRuedaDelIzq = new Parte();
            parteRuedaDelIzq.Add("cara11", caras["rueda1"]);

            var parteRuedaDelDer = new Parte();
            parteRuedaDelDer.Add("cara12", caras["rueda2"]);

            var parteRuedaTrasIzq = new Parte();
            parteRuedaTrasIzq.Add("cara13", caras["rueda3"]);


            var parteRuedaTrasDer = new Parte();
            parteRuedaTrasDer.Add("cara14", caras["rueda4"]);


            objetoAuto.Add("cuerpo", parteCuerpo);
            objetoAuto.Add("techo", parteTecho);
            objetoAuto.Add("ruedaDelIzq", parteRuedaDelIzq);
            objetoAuto.Add("ruedaDelDer", parteRuedaDelDer);
            objetoAuto.Add("ruedaTrasIzq", parteRuedaTrasIzq);
            objetoAuto.Add("ruedaTrasDer", parteRuedaTrasDer);

            escenario.Add("auto1", objetoAuto);
        }



        private void CargarEscenario2()
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

          
           // Serializar.GuardarJson(new Dictionary<string, Escenario> { { "escenario", escenario } }, "datos.json");
        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10, 10, -10, 10, -10, 10);

            var grupo = new GrupoDeAcciones();
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "ruedaDelIzq"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "ruedaDelIzq"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "ruedaDelDer"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "ruedaDelDer"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "ruedaTrasIzq"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "ruedaTrasIzq"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "ruedaTrasDer"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "ruedaTrasDer"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "cuerpo"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "cuerpo"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "rotar",
                Angulo = 0f,
                Duracion = 4f,
                Objetivo = "techo"
            });
            grupo.Acciones.Add(new Accion
            {
                Tipo = "trasladar",
                Vector = new Vector3(5f, 0f, 0f),
                Duracion = 2f,
                Objetivo = "techo"
            });

            libreto.Grupos.Clear();
            libreto.Grupos.Add(grupo);

            
            animacion.AddLibreto(libreto);
            libreto.escenario = escenario;

            //var escenarios = Serializar.CargarJson("datos.json");
            //escenario = escenarios.ContainsKey("escenario") ? escenarios["escenario"] : new Escenario();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.PushMatrix();
            GL.Rotate(90f, 1f, 0f, 0f); // Echar hacia atrás
            GL.Scale(2.0f, 1.0f, 1.0f); // Doblar el ancho en X
            escenario.Get("objetoU1").Draw(new Vertice(0.0f, 0.0f, 0.0f));
            GL.PopMatrix();

            // Dibujar la U
            GL.PushMatrix();
            escenario.Get("auto1").Draw(new Vertice(0.0f, 2.4f, 0.0f));
            GL.PopMatrix();


            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            animacion.ejecutar(escenario, e);
            libreto.Update((float)e.Time);


        }
       
    }
}
