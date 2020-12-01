using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometryRestApi
{
    public class PointInt
    {
        public string Name { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public void Translate(int deltaX, int deltaY)
        {
            checked
            {
                X += deltaX;
                Y += deltaY;
            }
        }

        public double Distance(PointInt other)
        {
            // before implementing function:
            // throw new NotImplementedException("Not implemented.");
            return Math.Sqrt(
                Math.Pow(X - other.X, 2)
                + Math.Pow(Y - other.Y, 2)
            );
        }
    }
}
