using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Parte
    {

        public string Nombre { get; set; }
        [JsonProperty]
        private Dictionary<string, Cara> caras = new Dictionary<string, Cara>();

        [JsonProperty]
        public Vertice centro { get; set; }
        

        // Nuevo campo para guardar el ángulo acumulado de rotación
        private float anguloRotacion = 0f;

        // Nuevo campo para guardar el eje de rotación (por defecto z)
        private char ejeRotacion = 'z';


        public Parte()
        {
            this.centro = new Vertice(0.0f, 0.0f, 0.0f);
        }
        public void Add(string id, Cara cara)
        {
            caras[id] =cara;
        }

        public Cara Get(string id)
        {
            return caras.ContainsKey(id) ? caras[id] : null;
        }

        public void Delete(string id)
        {
            caras.Remove(id);
        }

        // Permite establecer el eje de rotación ('x', 'y' o 'z')
        public void SetEjeRotacion(char eje)
        {
            ejeRotacion = eje;
        }

        // Método para agregar rotación acumulada
        public void AgregarRotacion(float grados)
        {
            anguloRotacion += grados;
        }
        public void Draw(Vertice c)
        {
            Vertice nuevocentro = new Vertice(c.X, c.Y, c.Z);
            nuevocentro += centro;
            GL.PushMatrix();

            // Mover al centro de la parte
            GL.Translate(nuevocentro.X, nuevocentro.Y, nuevocentro.Z);

            // Aplicar la rotación acumulada según el eje
            switch (ejeRotacion)
            {
                case 'x':
                    GL.Rotate(anguloRotacion, 1f, 0f, 0f);
                    break;
                case 'y':
                    GL.Rotate(anguloRotacion, 0f, 1f, 0f);
                    break;
                case 'z':
                default:
                    GL.Rotate(anguloRotacion, 0f, 0f, 1f);
                    break;
            }

            // Dibujar cada cara, pero esta vez desde (0,0,0) porque ya movimos y rotamos
            foreach (var cara in caras.Values)
            {
                cara.Draw(new Vertice(0f, 0f, 0f));
            }

            GL.PopMatrix();
        }

        public void TransladarParte(float x, float y, float z)
        {
            foreach (Cara cara in caras.Values)
            {
                cara.Trasladar(x, y, z);
            }
        }

        public void ScalarParte(float n)
        {
            foreach (Cara poligono in caras.Values)
            {
                poligono.Scalar(n);
            }
        }

        public void RotarParte(string axis, float grades)
        {
            foreach (Cara poligono in caras.Values)
            {
                poligono.Rotar(axis, grades);
            }
        }

    }
}
