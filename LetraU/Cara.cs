using Newtonsoft.Json;
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

        public void Draw()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color);
            foreach (var vertice in vertices.Values)
            {
                GL.Vertex3(vertice.X, vertice.Y, vertice.Z);
            }
            GL.End();
        }
    }
}
