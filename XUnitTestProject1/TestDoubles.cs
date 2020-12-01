using Xunit;

namespace XUnitTestProject1
{
    public class TestDoubles
    {
        [Fact]
        public void InfinityTest()
        {
            Assert.Equal(double.PositiveInfinity, 1.5 + double.PositiveInfinity);
            Assert.Equal(double.PositiveInfinity, double.PositiveInfinity + double.PositiveInfinity);
            Assert.Equal(double.PositiveInfinity, 1.5 * double.PositiveInfinity);
            Assert.Equal(double.NegativeInfinity, -1.5 * double.PositiveInfinity);
            Assert.Equal(double.PositiveInfinity, double.PositiveInfinity * double.PositiveInfinity);
            Assert.Equal(0.0, 1.5 / double.PositiveInfinity);
            Assert.Equal(0.0, -1.5 / double.PositiveInfinity);
            Assert.True(double.IsNaN(double.PositiveInfinity / double.PositiveInfinity));
            Assert.Equal(double.PositiveInfinity, 1.5 / 0.0);
            Assert.Equal(double.NegativeInfinity, -1.5 / 0.0);
            Assert.True(double.IsNaN(0.0 / 0.0));
        }

        [Fact]
        public void NaNTest()
        {
            Assert.True(double.IsNaN(1.5 + double.NaN));
            Assert.True(double.IsNaN(double.PositiveInfinity + double.NaN));
            Assert.True(double.IsNaN(double.NaN + double.NaN));
            Assert.True(double.IsNaN(1.5 - double.NaN));
            Assert.True(double.IsNaN(double.PositiveInfinity - double.NaN));
            Assert.True(double.IsNaN(double.NaN - double.NaN));
            Assert.True(double.IsNaN(1.5 * double.NaN));
            Assert.True(double.IsNaN(double.PositiveInfinity * double.NaN));
            Assert.True(double.IsNaN(double.NaN * double.NaN));
            Assert.True(double.IsNaN(1.5 / double.NaN));
            Assert.True(double.IsNaN(double.PositiveInfinity / double.NaN));
            Assert.True(double.IsNaN(double.NaN / double.NaN));
        }

        [Fact]
        void ExactComputationTest()
        {
            var price = 0.25;
            Assert.Equal(0.5, 2 * price);
            Assert.Equal(0.75, 3 * price);
        }

        [Fact]
        void ComputationWithPrecisionTest()
        {
            var price = 0.1; // this number has no exact represention in IEEE754
            var precision = 15; // for precision 1E-15
            Assert.Equal(0.2, 2 * price); // *2 has effect on exponent part only: +1
            Assert.False(0.3 == 3 * price); // 0.30000000000000004
            // give expected precision for computation with rounding or base 10/2 conversion imprecision
            Assert.Equal(0.3, 3 * price, precision); 
        }

        // NB: decimal type is better for money data (an int is used at low level for computing)
        [Fact]
        void ComputationWithPrecisionDecimalTest()
        {
            decimal price = 0.1m; // this number has exact in decimal format (fixed point)
            Assert.Equal(0.2m, 2 * price); // still exact
            Assert.Equal(0.3m, 3 * price); // exact computation !
            Assert.Equal(0.033m,  price / 3, 3); // this one needs precision
        }
    }
}
