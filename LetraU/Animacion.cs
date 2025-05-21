using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    public class Animacion
    {

        public List<Libreto> listalibretos;
        public int siguiente;
        public Libreto libreto;

        private float tiempoTrans, ultimoTiempo;
        private float FPS;

        public Animacion()
        {
            listalibretos = new List<Libreto>();
            siguiente = -1;
            tiempoTrans = 0;
            ultimoTiempo = 0;
            FPS = 0.0f;
            libreto = null;
        }

        private float CalcularFPS()
        {
            float fps = 1;
            if (tiempoTrans - ultimoTiempo > 0.0)
            {
                fps = 1.0f / (tiempoTrans - ultimoTiempo);
            }
            return fps;
        }

        public void AddLibreto(Libreto libreto)
        {
            listalibretos.Add(libreto);
        }

        public Libreto SiguienteLibreto()
        {
            siguiente++;
            if (siguiente < listalibretos.Count())
            {
                return listalibretos.ElementAt(siguiente);
            }
            return null;
        }

       
        public void ejecutar(Escenario escenario, FrameEventArgs e)
        {
            float deltaTime = (float)e.Time;
            tiempoTrans += deltaTime;
            FPS = CalcularFPS();
            ultimoTiempo = tiempoTrans;

            if (libreto == null)
            {
                libreto = SiguienteLibreto();
            }
            else
            {
                if (libreto.FinEjecucion(tiempoTrans))
                {
                    libreto = SiguienteLibreto();
                }
                else
                {
                    libreto.Update(deltaTime);  
                }
            }

        }
    }
}
