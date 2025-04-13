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

        public void Draw()
        {
            foreach (var parte in partes.Values)
            {
                parte.Draw();
            }
        }
    }
}
