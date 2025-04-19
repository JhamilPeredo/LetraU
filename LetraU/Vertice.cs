using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{

    [JsonObject(MemberSerialization.OptIn)]
    public class Vertice
    {
        [JsonProperty]
        public float X { get; set; }
        [JsonProperty]
        public float Y { get; set; }
        [JsonProperty]
        public float Z { get; set; }

        [JsonConstructor]
        public Vertice(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vertice operator +(Vertice p1, Vertice p2)
        {
            Vertice nuevovertice = new Vertice(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
            return nuevovertice;
        }

        public static Vertice operator *(Vertice p1, float r)
        {
            Vertice nuevovertice = new Vertice(p1.X * r, p1.Y * r, p1.Z * r);
            return nuevovertice;
        }

        
             /*   public static Dictionary<string, Cara> CrearCaras()
                {
                    var caras = new Dictionary<string, Cara>();
                    var caraInferiorFrontal = new Cara();
                    caraInferiorFrontal.Add("lado1", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraInferiorFrontal.Add("lado2", new Vertice(2.0f, -1.0f, 0.5f));
                    caraInferiorFrontal.Add("lado3", new Vertice(2.0f, -1.5f, 0.5f));
                    caraInferiorFrontal.Add("lado4", new Vertice(-2.0f, -1.5f, 0.5f));
                    caraInferiorFrontal.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInferiorFrontal"] = caraInferiorFrontal;

                    // Cara 2: Parte inferior trasera
                    var caraInferiorTrasera = new Cara();
                    caraInferiorTrasera.Add("lado1", new Vertice(-2.0f, -1.0f, -0.5f));
                    caraInferiorTrasera.Add("lado2", new Vertice(2.0f, -1.0f, -0.5f));
                    caraInferiorTrasera.Add("lado3", new Vertice(2.0f, -1.5f, -0.5f));
                    caraInferiorTrasera.Add("lado4", new Vertice(-2.0f, -1.5f, -0.5f));
                    caraInferiorTrasera.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInferiorTrasera"] = caraInferiorTrasera;

                    // Cara 3: Parte superior frontal
                    var caraSuperiorFrontal = new Cara();
                    caraSuperiorFrontal.Add("lado1", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraSuperiorFrontal.Add("lado2", new Vertice(2.0f, -1.0f, 0.5f));
                    caraSuperiorFrontal.Add("lado3", new Vertice(2.0f, -1.5f, 0.5f));
                    caraSuperiorFrontal.Add("lado4", new Vertice(-2.0f, -1.5f, 0.5f));
                    caraSuperiorFrontal.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorFrontal"] = caraSuperiorFrontal;

                    // Cara 4: Parte superior trasera
                    var caraSuperiorTrasera = new Cara();
                    caraSuperiorTrasera.Add("lado1", new Vertice(-2.0f, -1.5f, 0.5f));
                    caraSuperiorTrasera.Add("lado2", new Vertice(2.0f, -1.5f, 0.5f));
                    caraSuperiorTrasera.Add("lado3", new Vertice(2.0f, -1.5f, -0.5f));
                    caraSuperiorTrasera.Add("lado4", new Vertice(-2.0f, -1.5f, -0.5f));
                    caraSuperiorTrasera.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorTrasera"] = caraSuperiorTrasera;

                    // Cara 5: Lateral derecho frontal
                    var caraLateralDerechaFrontal = new Cara();
                    caraLateralDerechaFrontal.Add("lado1", new Vertice(2.0f, -1.0f, 0.5f));
                    caraLateralDerechaFrontal.Add("lado2", new Vertice(2.0f, -1.5f, 0.5f));
                    caraLateralDerechaFrontal.Add("lado3", new Vertice(2.0f, -1.5f, -0.5f));
                    caraLateralDerechaFrontal.Add("lado4", new Vertice(2.0f, -1.0f, -0.5f));
                    caraLateralDerechaFrontal.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraLateralDerechaFrontal"] = caraLateralDerechaFrontal;

                    // Cara 6: Lateral izquierdo frontal
                    var caraLateralIzquierdaFrontal = new Cara();
                    caraLateralIzquierdaFrontal.Add("lado1", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraLateralIzquierdaFrontal.Add("lado2", new Vertice(-2.0f, -1.5f, 0.5f));
                    caraLateralIzquierdaFrontal.Add("lado3", new Vertice(-2.0f, -1.5f, -0.5f));
                    caraLateralIzquierdaFrontal.Add("lado4", new Vertice(-2.0f, -1.0f, -0.5f));
                    caraLateralIzquierdaFrontal.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraLateralIzquierdaFrontal"] = caraLateralIzquierdaFrontal;

                    // Cara 7: Parte interior izquierda (horizontal)
                    var caraInteriorIzquierda = new Cara();
                    caraInteriorIzquierda.Add("lado1", new Vertice(-2.0f, 1.5f, 0.5f));
                    caraInteriorIzquierda.Add("lado2", new Vertice(-1.5f, 1.5f, 0.5f));
                    caraInteriorIzquierda.Add("lado3", new Vertice(-1.5f, -1.0f, 0.5f));
                    caraInteriorIzquierda.Add("lado4", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraInteriorIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInteriorIzquierda"] = caraInteriorIzquierda;

                    // Cara 8: Parte interior derecha (horizontal)
                    var caraInteriorDerecha = new Cara();
                    caraInteriorDerecha.Add("lado1", new Vertice(-2.0f, 1.5f, -0.5f));
                    caraInteriorDerecha.Add("lado2", new Vertice(-1.5f, 1.5f, -0.5f));
                    caraInteriorDerecha.Add("lado3", new Vertice(-1.5f, -1.0f, -0.5f));
                    caraInteriorDerecha.Add("lado4", new Vertice(-2.0f, -1.0f, -0.5f));
                    caraInteriorDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInteriorDerecha"] = caraInteriorDerecha;

                    // Cara 9: Parte superior interna izquierda
                    var caraSuperiorInternaIzquierda = new Cara();
                    caraSuperiorInternaIzquierda.Add("lado1", new Vertice(-2.0f, 1.5f, 0.5f));
                    caraSuperiorInternaIzquierda.Add("lado2", new Vertice(-1.5f, 1.5f, 0.5f));
                    caraSuperiorInternaIzquierda.Add("lado3", new Vertice(-1.5f, 1.5f, -0.5f));
                    caraSuperiorInternaIzquierda.Add("lado4", new Vertice(-2.0f, 1.5f, -0.5f));
                    caraSuperiorInternaIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorInternaIzquierda"] = caraSuperiorInternaIzquierda;

                    // Cara 10: Parte superior interna derecha
                    var caraSuperiorInternaDerecha = new Cara();
                    caraSuperiorInternaDerecha.Add("lado1", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraSuperiorInternaDerecha.Add("lado2", new Vertice(-1.5f, -1.0f, 0.5f));
                    caraSuperiorInternaDerecha.Add("lado3", new Vertice(-1.5f, -1.0f, -0.5f));
                    caraSuperiorInternaDerecha.Add("lado4", new Vertice(-2.0f, -1.0f, -0.5f));
                    caraSuperiorInternaDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorInternaDerecha"] = caraSuperiorInternaDerecha;

                    // Cara 11: Cara superior izquierda
                    var caraSuperiorIzquierda = new Cara();
                    caraSuperiorIzquierda.Add("lado1", new Vertice(-1.5f, 1.5f, 0.5f));
                    caraSuperiorIzquierda.Add("lado2", new Vertice(-1.5f, -1.0f, 0.5f));
                    caraSuperiorIzquierda.Add("lado3", new Vertice(-1.5f, -1.0f, -0.5f));
                    caraSuperiorIzquierda.Add("lado4", new Vertice(-1.5f, 1.5f, -0.5f));
                    caraSuperiorIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorIzquierda"] = caraSuperiorIzquierda;

                    // Cara 12: Cara superior derecha
                    var caraSuperiorDerecha = new Cara();
                    caraSuperiorDerecha.Add("lado1", new Vertice(-2.0f, 1.5f, 0.5f));
                    caraSuperiorDerecha.Add("lado2", new Vertice(-2.0f, -1.0f, 0.5f));
                    caraSuperiorDerecha.Add("lado3", new Vertice(-2.0f, -1.0f, -0.5f));
                    caraSuperiorDerecha.Add("lado4", new Vertice(-2.0f, 1.5f, -0.5f));
                    caraSuperiorDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraSuperiorDerecha"] = caraSuperiorDerecha;

                    // Cara 13: Cara trasera izquierda
                    var caraTraseraIzquierda = new Cara();
                    caraTraseraIzquierda.Add("lado1", new Vertice(1.5f, 1.5f, 0.5f));
                    caraTraseraIzquierda.Add("lado2", new Vertice(2.0f, 1.5f, 0.5f));
                    caraTraseraIzquierda.Add("lado3", new Vertice(2.0f, -1.0f, 0.5f));
                    caraTraseraIzquierda.Add("lado4", new Vertice(1.5f, -1.0f, 0.5f));
                    caraTraseraIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraTraseraIzquierda"] = caraTraseraIzquierda;

                    // Cara 14: Cara trasera derecha
                    var caraTraseraDerecha = new Cara();
                    caraTraseraDerecha.Add("lado1", new Vertice(1.5f, 1.5f, -0.5f));
                    caraTraseraDerecha.Add("lado2", new Vertice(2.0f, 1.5f, -0.5f));
                    caraTraseraDerecha.Add("lado3", new Vertice(2.0f, -1.0f, -0.5f));
                    caraTraseraDerecha.Add("lado4", new Vertice(1.5f, -1.0f, -0.5f));
                    caraTraseraDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraTraseraDerecha"] = caraTraseraDerecha;

                    // Cara 15: Parte interna inferior izquierda
                    var caraInferiorInternaIzquierda = new Cara();
                    caraInferiorInternaIzquierda.Add("lado1", new Vertice(1.5f, 1.5f, 0.5f));
                    caraInferiorInternaIzquierda.Add("lado2", new Vertice(2.0f, 1.5f, 0.5f));
                    caraInferiorInternaIzquierda.Add("lado3", new Vertice(2.0f, 1.5f, -0.5f));
                    caraInferiorInternaIzquierda.Add("lado4", new Vertice(1.5f, 1.5f, -0.5f));
                    caraInferiorInternaIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInferiorInternaIzquierda"] = caraInferiorInternaIzquierda;

                    // Cara 16: Parte inferior interna derecha
                    var caraInferiorInternaDerecha = new Cara();
                    caraInferiorInternaDerecha.Add("lado1", new Vertice(1.5f, -1.0f, 0.5f));
                    caraInferiorInternaDerecha.Add("lado2", new Vertice(2.0f, -1.0f, 0.5f));
                    caraInferiorInternaDerecha.Add("lado3", new Vertice(2.0f, -1.0f, -0.5f));
                    caraInferiorInternaDerecha.Add("lado4", new Vertice(1.5f, -1.0f, -0.5f));
                    caraInferiorInternaDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraInferiorInternaDerecha"] = caraInferiorInternaDerecha;

                    // Cara 17: Lateral superior izquierda
                    var caraLateralSuperiorIzquierda = new Cara();
                    caraLateralSuperiorIzquierda.Add("lado1", new Vertice(2.0f, 1.5f, 0.5f));
                    caraLateralSuperiorIzquierda.Add("lado2", new Vertice(2.0f, -1.0f, 0.5f));
                    caraLateralSuperiorIzquierda.Add("lado3", new Vertice(2.0f, -1.0f, -0.5f));
                    caraLateralSuperiorIzquierda.Add("lado4", new Vertice(2.0f, 1.5f, -0.5f));
                    caraLateralSuperiorIzquierda.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraLateralSuperiorIzquierda"] = caraLateralSuperiorIzquierda;

                    // Cara 18: Lateral superior derecha
                    var caraLateralSuperiorDerecha = new Cara();
                    caraLateralSuperiorDerecha.Add("lado1", new Vertice(1.5f, 1.5f, 0.5f));
                    caraLateralSuperiorDerecha.Add("lado2", new Vertice(1.5f, -1.0f, 0.5f));
                    caraLateralSuperiorDerecha.Add("lado3", new Vertice(1.5f, -1.0f, -0.5f));
                    caraLateralSuperiorDerecha.Add("lado4", new Vertice(1.5f, 1.5f, -0.5f));
                    caraLateralSuperiorDerecha.Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f);
                    caras["caraLateralSuperiorDerecha"] = caraLateralSuperiorDerecha;

                    return caras;


                }

              */
        

    }

}
