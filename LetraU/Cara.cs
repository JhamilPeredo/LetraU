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
    public class Cara
    {
        [JsonProperty]
        private Dictionary<string, Vertice> vertices = new Dictionary<string, Vertice>();

        [JsonProperty]
        public Color4 Color { get; set; }

        [JsonProperty]
        public Vertice centro { get; set; }

        private Matrix4 transformaciones;
        private Matrix4 transformacionesInversas;

        public Cara()
        {
            this.centro = new Vertice(0.0f, 0.0f, 0.0f);
            transformaciones = Matrix4.Identity;
            transformacionesInversas = Matrix4.Identity;
        }

        public void Add(string id, Vertice vertice)
        {
            vertices[id] = vertice;
        }

        public Vertice Get(string id)
        {
            return vertices.ContainsKey(id) ? vertices[id] : null;
        }

        public void Delete(string id)
        {
            vertices.Remove(id);
        }

        public void Draw(Vertice c)
        {
            GL.PushMatrix();
            Vertice nuevocentro = new Vertice(c.X, c.Y, c.Z);
            nuevocentro += centro;
            GL.Translate(new Vector3(nuevocentro.X, nuevocentro.Y, nuevocentro.Z));
            GL.MultMatrix(ref transformaciones);
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color);

            foreach (var vertice in vertices.Values)
            {
                GL.Vertex3(vertice.X, vertice.Y, vertice.Z);
            }
            GL.End();
            GL.PopMatrix();
        }

        public void Trasladar(float x, float y, float z)
        {
            transformaciones = Matrix4.Mult(transformaciones, Matrix4.CreateTranslation(x, y, z));
            transformacionesInversas = Matrix4.Mult(Matrix4.CreateTranslation(-x, -y, -z), transformacionesInversas);
        }



        public void Scalar(float n)
        {
            transformaciones = Matrix4.Mult(transformaciones, Matrix4.CreateScale(n));
            transformacionesInversas = Matrix4.Mult(Matrix4.CreateScale(1.0f / n), transformacionesInversas);
        }

        public void Rotar(string eje, float grados)
        {
            float r = MathHelper.DegreesToRadians(grados);
            Matrix4 rotationMatrix = Matrix4.Identity;

            if (eje == "x")
                rotationMatrix = Matrix4.CreateRotationX(r);
            else if (eje == "y")
                rotationMatrix = Matrix4.CreateRotationY(r);
            else if (eje == "z")
                rotationMatrix = Matrix4.CreateRotationZ(r);

            transformaciones = Matrix4.Mult(transformaciones, rotationMatrix);
            transformacionesInversas = Matrix4.Mult(rotationMatrix, transformacionesInversas);
        }
    }
}
