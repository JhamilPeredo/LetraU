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

        public void Draw()
        {
            foreach (var cara in caras.Values)
            {
                cara.Draw();
            }
        }


    }
}
