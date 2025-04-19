using Newtonsoft.Json;
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
        [JsonProperty]
        private Dictionary<string, Cara> caras = new Dictionary<string, Cara>();

        [JsonProperty]
        public Vertice centro { get; set; }

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

        public void Draw(Vertice c)
        {
            Vertice nuevocentro = new Vertice(c.X, c.Y, c.Z);
            nuevocentro += centro;
            foreach (var cara in caras.Values)
            {
                cara.Draw(nuevocentro);
            }
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
