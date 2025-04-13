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

        public void Add(string id, Objeto objeto)
        {
            objetos[id] = objeto;
        }

        public Objeto Get(string id)
        {
            return objetos.ContainsKey(id) ? objetos[id] : null;
        }

        public void Delete(string id)
        {
            objetos.Remove(id);
        }

        public void Draw()
        {
            foreach (var objeto in objetos.Values)
            {
                objeto.Draw();
            }
        }

    }
}
