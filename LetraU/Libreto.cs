using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetraU
{
    public class Libreto
    {
        public List<GrupoDeAcciones> Grupos = new List<GrupoDeAcciones>();
        private float tiempoTranscurrido = 0f;
        private int grupoActualIndex = 0;

        public Escenario escenario;

        public bool FinEjecucion(float tiempo)
        {
            return grupoActualIndex >= Grupos.Count;
        }

        public void Update(float deltaTime)
        {
            if (grupoActualIndex >= Grupos.Count) return;

            tiempoTranscurrido += deltaTime;

            GrupoDeAcciones grupo = Grupos[grupoActualIndex];

            bool grupoTerminado = true;

            foreach (var accion in grupo.Acciones)
            {
                if (accion.Duracion <= 0f) continue;

                float progreso = tiempoTranscurrido / accion.Duracion;
                if (progreso < 1f) grupoTerminado = false;

                var objetivo = escenario.BuscarParte(accion.Objetivo); 
                if (objetivo == null) continue;

                switch (accion.Tipo)
                {
                    case "trasladar":
                        objetivo.TransladarParte(
                            accion.Vector.X * deltaTime / accion.Duracion,
                            accion.Vector.Y * deltaTime / accion.Duracion,
                            accion.Vector.Z * deltaTime / accion.Duracion
                        );
                        break;

                    case "rotar":
                        objetivo.RotarParte("x", accion.Angulo * deltaTime / accion.Duracion);
                        break;

                    case "escalar":
                        float escala = 1 + (accion.Vector.X - 1) * deltaTime / accion.Duracion;
                        objetivo.ScalarParte(escala);
                        break;
                }
            }

            if (grupoTerminado)
            {
                tiempoTranscurrido = 0f;
                grupoActualIndex++;
            }
        }
    }

    public class GrupoDeAcciones
    {
        public List<Accion> Acciones = new List<Accion>();
    }
}
