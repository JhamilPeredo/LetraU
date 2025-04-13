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
        public static void GuardarJson(Dictionary<string, Cara> caras, string filePath)
        {
            string json = JsonConvert.SerializeObject(caras, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static Dictionary<string, Cara> CargarJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Cara>>(json);
        }
    }
}
