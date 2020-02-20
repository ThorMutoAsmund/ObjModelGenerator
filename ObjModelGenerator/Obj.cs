using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjModelGenerator
{
    public abstract class Obj
    {
        public string Name { get; set; }
        public List<Face> Faces { get; set; } = new List<Face>();
        public List<Vector3> Vectors { get; set; } = new List<Vector3>();

        protected Vector2 V2(double x, double y) => new Vector2(x, y);
        protected Vector3 V3(double x, double y, double z) => new Vector3(x, y, z);
                
        public Vector3[] Bezier(Vector2 pt0, Vector2 pt1, Vector2 pt2, Vector2 pt3, double z, int divisions)
        {
            double x0 = pt0.x, x1 = pt1.x, x2 = pt2.x, x3 = pt3.x;
            double y0 = pt0.y, y1 = pt1.y, y2 = pt2.y, y3 = pt3.y;

            var spline = new Vector3[divisions];
            for (var i = 0; i<divisions; ++i )
            {
                var t = (double)i / divisions;
                var x =
                    x0 * Math.Pow((1 - t), 3) +
                    x1 * 3 * t * Math.Pow((1 - t), 2) +
                    x2 * 3 * Math.Pow(t, 2) * (1 - t) +
                    x3 * Math.Pow(t, 3);
                var y = y0 * Math.Pow((1 - t), 3) +
                    y1 * 3 * t * Math.Pow((1 - t), 2) +
                    y2 * 3 * Math.Pow(t, 2) * (1 - t) +
                    y3 * Math.Pow(t, 3);
                spline[i] = V3(x, y, z);
            }
            return spline;
        }

        public string Export()
        {
            var output = new StringWriter();

            output.WriteLine($"# {this.Name}");

            output.WriteLine($"# Vectors");
            foreach (var vector in this.Vectors)
            {
                output.WriteLine($"v {vector.x} {vector.y} {vector.z}");
            }

            output.WriteLine($"# Faces");
            foreach (var face in this.Faces)
            {
                output.Write($"f");
                foreach (var index in face)
                {
                    output.Write($" {index}");
                }
                output.WriteLine();
            }

            return output.ToString();
        }

        protected int AddVector(Vector3 vector)
        {
            this.Vectors.Add(vector);
            return this.Vectors.Count();
        }
        protected void AddFace(Face face)
        {
            this.Faces.Add(face);
        }
        protected void AddFace(params int[] indices)
        {
            this.Faces.Add(new Face(indices));
        }
    }
}
