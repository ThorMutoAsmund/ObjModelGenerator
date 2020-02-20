using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjModelGenerator
{
    public class Ramp1 : Ramp
    {
        public Ramp1() :
            base(2)
        {

        }
    }
    public class Ramp2 : Ramp
    {
        public Ramp2() :
            base(1.5)
        {

        }
    }
    public class Ramp3 : Ramp
    {
        public Ramp3() :
            base(2.5)
        {

        }
    }

    public class Ramp : Obj
    {
        public Ramp(double controlLength = 2)
        {
            var divisions = 20;
            var last = divisions - 1;

            // Start points
            var startFrontLow = V3(-5, 0, -2);
            var idxStartFrontLow = AddVector(startFrontLow);
            var idxStartBackLow = AddVector(startFrontLow.With(z: 2));
            var idxStartBackHigh = AddVector(startFrontLow.With(z: 2).Add(y: 1));
            var idxStartFrontHigh = AddVector(startFrontLow.Add(y: 1));

            // Splines front and back
            var splFrontLow = Bezier(V2(-2, 0), V2(-2+ controlLength, 0), V2(2- controlLength, 2), V2(2, 2), -2, divisions);
            var splBackLow = splFrontLow.With(z: 2);
            var splFrontHigh = splFrontLow.Add(y: 1);
            var splBackHigh = splBackLow.Add(y: 1);

            // Get indices
            var idxFrontLow = splFrontLow.Select(v => AddVector(v)).ToArray();
            var idxFrontHigh = splFrontHigh.Select(v => AddVector(v)).ToArray();
            var idxBackLow = splBackLow.Select(v => AddVector(v)).ToArray();
            var idxBackHigh = splBackHigh.Select(v => AddVector(v)).ToArray();

            // End points
            var endFrontLow = V3(5, 2, -2);
            var idxEndFrontLow = AddVector(endFrontLow);
            var idxEndBackLow = AddVector(endFrontLow.With(z: 2));
            var idxEndBackHigh = AddVector(endFrontLow.With(z: 2).Add(y: 1));
            var idxEndFrontHigh = AddVector(endFrontLow.Add(y: 1));

            // End caps
            AddFace(idxStartFrontLow, idxStartBackLow, idxStartBackHigh, idxStartFrontHigh);
            AddFace(idxEndFrontLow, idxEndFrontHigh, idxEndBackHigh, idxEndBackLow);

            // Sides
            AddFace(idxStartFrontLow, idxStartFrontHigh, idxFrontHigh[0], idxFrontLow[0]);
            AddFace(idxStartBackHigh, idxStartBackLow, idxBackLow[0], idxBackHigh[0]);
            for (int i = 0; i < divisions - 1; ++i)
            {
                AddFace(idxFrontLow[i], idxFrontHigh[i], idxFrontHigh[i + 1], idxFrontLow[i + 1]);
                AddFace(idxBackHigh[i], idxBackLow[i], idxBackLow[i + 1], idxBackHigh[i + 1]);
            }
            AddFace(idxFrontLow[last], idxFrontHigh[last], idxEndFrontHigh, idxEndFrontLow);
            AddFace(idxBackHigh[last], idxBackLow[last], idxEndBackLow, idxEndBackHigh);

            // Top/bottom
            AddFace(idxStartFrontHigh, idxStartBackHigh, idxBackHigh[0], idxFrontHigh[0]);
            AddFace(idxStartBackLow, idxStartFrontLow, idxFrontLow[0], idxBackLow[0]);
            for (int i = 0; i < divisions - 1; ++i)
            {
                AddFace(idxFrontHigh[i], idxBackHigh[i], idxBackHigh[i + 1], idxFrontHigh[i + 1]);
                AddFace(idxBackLow[i], idxFrontLow[i], idxFrontLow[i + 1], idxBackLow[i + 1]);
            }
            AddFace(idxFrontHigh[last], idxBackHigh[last], idxEndBackHigh, idxEndFrontHigh);
            AddFace(idxBackLow[last], idxFrontLow[last], idxEndFrontLow, idxEndBackLow);


            //foreach (var p in s2)
            //{
            //    Console.WriteLine($"{p.x:G4} {p.y:G4} {p.z:G4}");
            //}
            //Console.ReadLine();

        }
    }
}
