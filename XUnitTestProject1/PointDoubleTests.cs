using Xunit;
using GeometryRestApi;

namespace XUnitTestProject1
{
    public class PointDoubleTests
    {
        [Fact]
        public void DistanceSuccessTest()
        {
            // before implementing test:
            // throw new NotImplementedException();

            // given
            var point1 = new PointDouble
            {
                Name = "A",
                X = 1.25,
                Y = 7.5
            };
            var point2 = new PointDouble
            {
                Name = "A",
                X = 5.25,
                Y = 4.5
            };
            var expectedDistance = 5.0;
            // when
            var computedDistance = point1.Distance(point2);
            // then
            Assert.Equal(expectedDistance, computedDistance);
        }

        [Fact]
        public void DistanceBigDoubleSuccesTest()
        {
            // before implementing test:
            // throw new NotImplementedException();

            // given
            var point1 = new PointDouble
            {
                Name = "A",
                X = 1.25E307,
                Y = 7.5E307
            };
            var point2 = new PointDouble
            {
                Name = "A",
                X = 5.25E307,
                Y = 4.5E307
            };
            var expectedDistance = 5.0E307;
            // when
            var computedDistance = point1.Distance(point2);
            // then
            Assert.Equal(expectedDistance, computedDistance);
        }
        
        [Fact]
        public void DistanceInfiniteDoubleSuccesTest()
        {
            // given
            var point1 = new PointDouble
            {
                Name = "A",
                X = 1.25E307,
                Y = 7.5E307
            };
            var point2 = new PointDouble
            {
                Name = "A",
                X = double.PositiveInfinity,
                Y = 4.5E307
            };
            var expectedDistance = double.PositiveInfinity;
            // when
            var computedDistance = point1.Distance(point2);
            // then
            Assert.Equal(expectedDistance, computedDistance);
        }

        [Theory]
        [InlineData(4.25, 6.125)]
        [InlineData(-4.25, 6.125)]
        [InlineData(4.25, -6.125)]
        [InlineData(-4.25, -6.125)]
        public void TranslateSuccessTest(double deltaX, double deltaY)
        {
            // given (classic values)
            var x = 1.25;
            var y = 3.5;
            var point = new PointDouble
            {
                Name = "A",
                X = x,
                Y = y
            };
            // when
            point.Translate(deltaX, deltaY);
            // then
            Assert.Equal(x + deltaX, point.X);
            Assert.Equal(y + deltaY, point.Y);
        }

        [Fact]
        public void TranslateInfiniteSuccessTest()
        {
            // given
            var x = 1.25;
            var y = 3.5;
            var deltaX = double.PositiveInfinity;
            var deltaY = double.NegativeInfinity;
            var point = new PointDouble
            {
                Name = "A",
                X = x,
                Y = y
            };
            // when/then
            point.Translate(deltaX, deltaY);
            // then
            Assert.Equal(double.PositiveInfinity, point.X);
            Assert.Equal(double.NegativeInfinity, point.Y);
        }

    }
}
