using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Escenario
    {
        [JsonProperty]
        private Dictionary<string, Objeto> objetos = new Dictionary<string, Objeto>();

        [JsonProperty]
        public Vertice centro { get; set; }

        public Escenario()
        {
            this.centro = new Vertice(0.0f, 0.0f, 0.0f);
        }

        public void Add(string id, Objeto objeto)
        {
            objetos[id] = objeto;
        }

        public Objeto Get(string id)
        {
            return objetos.ContainsKey(id) ? objetos[id] : null;
        }
        public Dictionary<string, Objeto> GetAll()
        {
            return objetos;
        }

        public void Delete(string id)
        {
            objetos.Remove(id);
        }

        public void Draw(Vertice c)
        {
            Vertice nuevocentro = new Vertice(c.X, c.Y, c.Z);
            nuevocentro += centro;
            foreach (var objeto in objetos.Values)
            {
                objeto.Draw(nuevocentro);
            }
        }

        public void TransladarEscenario(float x, float y, float z)
        {
            centro = new Vertice(centro.X + x, centro.Y + y, centro.Z + z);
            foreach (var objeto in objetos.Values)
            {
                objeto.TransladarObjeto(x, y, z);
            }
        }


        public void ScalarEscenario(float n)
        {
            foreach (var objeto in objetos.Values)
            {
                objeto.ScalarObjeto(n);
            }
        }


        public void RotarEscenario(string axis, float grados)
        {
            foreach (var objeto in objetos.Values)
            {
                objeto.RotarObjeto(axis, grados);
            }
        }
    }
}
