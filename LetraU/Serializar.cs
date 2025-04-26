using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    public class Serializar
    {
        public static void GuardarJson(Dictionary<string, Escenario> escenario, string filePath)
        {
            string json = JsonConvert.SerializeObject(escenario, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static Dictionary<string, Escenario> CargarJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Escenario>>(json);
        }
    }
}
