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

        public void translate(int deltaX, int deltaY)
        {
            throw new NotImplementedException("Not implemented.");
        }

        public double distance(PointInt other)
        {
            throw new NotImplementedException("Not implemented.");
        }
    }
}
