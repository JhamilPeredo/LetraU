using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    public class Program 
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\JHAMIL\source\repos\LetraU\LetraU\bin\Debug\datosT.json";
            // Crear un diccionario de polígonos para prueba
            //var cara = Vertice.CrearCaras();

            // Guardar el diccionario en un archivo JSON
          //  Serializar.GuardarJson(cara, filePath);

            // Cargar el diccionario desde el archivo JSON
            var cargarcaras = Serializar.CargarJson(filePath);

            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
}
