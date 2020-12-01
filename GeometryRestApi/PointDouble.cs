using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometryRestApi
{
    public class PointDouble
    {
        public string Name { get; set; }
        public double X { get; set; }

        public double Y { get; set; }

        public void Translate(double deltaX, double deltaY)
        {
            // throw new NotImplementedException("Not implemented.");
            X += deltaX;
            Y += deltaY;
        }

        public double Distance(PointDouble other)
        {
            //  throw new NotImplementedException("Not implemented.");
            // NB: other languages Java, Python C++ have hypot function
            return Math.Sqrt(
                Math.Pow(X - other.X, 2)
                + Math.Pow(Y - other.Y, 2)
            );
        }
    }
}
