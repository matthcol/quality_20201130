using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GeometryRestApi;

namespace XUnitTestProject1
{
    public class CollectionTests
    {
        [Fact]
        public void CollectionTest()
        {
            var points = new List<PointInt>() {
                new PointInt { Name = "A", X = 1, Y = 2 },
                new PointInt { Name = "B", X = 3, Y = 4 },
                new PointInt { Name = "C", X = 5, Y = 6 },
                new PointInt { Name = "D", X = 7, Y = 8 }
            };
            var xs = new List<int> { 1, 3, 5, 7 };
            Assert.All<PointInt>(points, p => Assert.True(p.Y < 10));
            Assert.All<PointInt>(points,
                p => Assert.InRange<int>(p.X, 1, 7));
            Assert.Equal<int>(xs, points.Select(p => p.X));
            Assert.Contains<PointInt>(points[1], points);
            var pointA = points[0];
            points.RemoveAt(0);
            Assert.DoesNotContain<PointInt>(pointA, points);
            Assert.NotEmpty(points);
            points.Clear();
            Assert.Empty(points);
        }
    }
}
