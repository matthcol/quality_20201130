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

        public void translate(double deltaX, double deltaY)
        {
            throw new NotImplementedException("Not implemented.");
        }

        public double distance(PointInt other)
        {
            throw new NotImplementedException("Not implemented.");
        }
    }
}
