using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    [JsonObject(MemberSerialization.OptIn)]
    public  class Objeto
    {
        [JsonProperty]
        private Dictionary<string, Parte> partes = new Dictionary<string, Parte>();

        [JsonProperty]
        public Vertice centro { get; set; }

        public Objeto()
        {
            this.centro = new Vertice(0.0f, 0.0f, 0.0f);

        }
        public void Add(string id, Parte parte)
        {
            partes[id] = parte;
        }

        public Parte Get(string id)
        {
            return partes.ContainsKey(id) ? partes[id] : null;
        }

        public void Delete(string id)
        {
            partes.Remove(id);
        }

        public void Draw(Vertice c)
        {
            Vertice nuevocentro = new Vertice(c.X, c.Y, c.Z);
            nuevocentro += centro;

            foreach (var parte in partes.Values)
            {
                parte.Draw(nuevocentro);
            }
        }


        public void TransladarObjeto(float x, float y, float z)
        {
            centro = new Vertice(centro.X + x, centro.Y + y, centro.Z + z);
            foreach (var parte in partes.Values)
            {
                parte.TransladarParte(x, y, z);
            }
        }

        public void ScalarObjeto(float n)
        {
            foreach (var parte in partes.Values)
            {
                parte.ScalarParte(n);
            }
        }

        public void RotarObjeto(string axis, float grados)
        {
            foreach (var parte in partes.Values)
            {
                parte.RotarParte(axis, grados);
            }
        }
    }
}
