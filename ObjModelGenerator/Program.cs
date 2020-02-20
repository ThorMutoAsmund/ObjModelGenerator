using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Road() { Name = nameof(Road) };
            System.IO.File.WriteAllText($"{obj.Name}.obj", obj.Export());
            //var obj = new Ramp1() { Name = nameof(Ramp1) };
            //System.IO.File.WriteAllText($"{obj.Name}.obj", obj.Export());
            //var obj2 = new Ramp2() { Name = nameof(Ramp2) };
            //System.IO.File.WriteAllText($"{obj2.Name}.obj", obj2.Export());
            //var obj3 = new Ramp3() { Name = nameof(Ramp3) };
            //System.IO.File.WriteAllText($"{obj3.Name}.obj", obj3.Export());
        }
    }
}
