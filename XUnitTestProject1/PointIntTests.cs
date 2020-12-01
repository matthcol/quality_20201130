using System;
using Xunit;
using GeometryRestApi;

namespace XUnitTestProject1
{
	// commentaire en français à moi
	// on peut aller à 東京
    public class PointIntTests
    {
        [Fact]
        public void DistanceSuccessTest()
        {
            // before implementing test:
            // throw new NotImplementedException();

            // given
            var point1 = new PointInt
            {
                Name = "A",
                X = 1,
                Y = 7
            };
            var point2 = new PointInt
            {
                Name = "A",
                X = 5,
                Y = 4
            };
            var expectedDistance = 5.0;
            // when
            var computedDistance = point1.Distance(point2);
            // then
            Assert.Equal(expectedDistance, computedDistance);
        }

        [Theory]
        [InlineData(5.0, 1, 7, 5, 4)]
        [InlineData(int.MaxValue, 0, 0, int.MaxValue, 0)]
        [InlineData(int.MaxValue+1.0, 0, 0, int.MinValue, 0)]
        public void DistanceManySuccessTest(double expectedDistance, int x1, int y1, int x2, int y2)
        {
            // given
            var point1 = new PointInt { Name = "A", X = x1, Y = y1 };
            var point2 = new PointInt { Name = "B", X = x2, Y = y2 };
            // when
            var computedDistance = point1.Distance(point2);
            // then
            Assert.Equal(expectedDistance, computedDistance);
        }

        [Fact]
        public void TranslateSuccessTest()
        {
            // given (classic values)
            var x = 1;
            var y = 3;
            var deltaX = 4;
            var deltaY = 6;
            var point = new PointInt
            {
                Name = "A",
                X = x,
                Y = y
            };
            // when
            point.Translate(deltaX, deltaY);
            // then
            Assert.Equal(x+ deltaX, point.X);
            Assert.Equal(y + deltaY, point.Y);
        }

        [Fact]
        public void TranslateMaxIntFailTest()
        {
            // given
            var x = 1;
            var y = 3;
            var deltaX = Int32.MaxValue;
            var deltaY = Int32.MaxValue;
            var point = new PointInt
            {
                Name = "A",
                X = x,
                Y = y
            };
            // when/then
            Assert.Throws<OverflowException>(
                () => point.Translate(deltaX, deltaY));
           // NB:  Assert.Equal(Int32.MinValue, deltaX + 1); // modulo
        }


    }
}
