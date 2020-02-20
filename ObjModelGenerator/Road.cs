using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjModelGenerator
{

    public class Road : Obj
    {
        public Road()
        {
            var height = 0.2;
            var length = 10.0;
            var width = 2.0;

            // Start points
            var startFrontLow = V3(-length/2, -height/2, -width/2);
            var idxStartFrontLow = AddVector(startFrontLow);
            var idxStartBackLow = AddVector(startFrontLow.With(z: width / 2));
            var idxStartBackHigh = AddVector(startFrontLow.With(z: width / 2).Add(y: height));
            var idxStartFrontHigh = AddVector(startFrontLow.Add(y: height));

            // End points
            var endFrontLow = V3(length / 2, -height / 2, -width / 2);
            var idxEndFrontLow = AddVector(endFrontLow);
            var idxEndBackLow = AddVector(endFrontLow.With(z: width / 2));
            var idxEndBackHigh = AddVector(endFrontLow.With(z: width / 2).Add(y: height));
            var idxEndFrontHigh = AddVector(endFrontLow.Add(y: height));

            // End caps
            AddFace(idxStartFrontLow, idxStartBackLow, idxStartBackHigh, idxStartFrontHigh);
            AddFace(idxEndFrontLow, idxEndFrontHigh, idxEndBackHigh, idxEndBackLow);

            // Sides
            AddFace(idxStartFrontLow, idxStartFrontHigh, idxEndFrontHigh, idxEndFrontLow);
            AddFace(idxStartBackHigh, idxStartBackLow, idxEndBackLow, idxEndBackHigh);

            // Top/bottom
            AddFace(idxStartFrontHigh, idxStartBackHigh, idxEndBackHigh, idxEndFrontHigh);
            AddFace(idxStartBackLow, idxStartFrontLow, idxEndFrontLow, idxEndBackLow);
        }
    }
}
