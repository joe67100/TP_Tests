using CreditApp;
using System.Numerics;

namespace CreditAppTest
{
    public class ValidatorsTests
    {
        [InlineData(0, 2, 5, true)]
        [InlineData(1, -2, 5, false)]
        [InlineData(2, 2, 2, true)]
        [InlineData(25, 2, 30, false)]
        [Theory]
        public void IsBetweenIntTest(int min, int value, int max, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsBetween(min, value, max);
            // Act
            Assert.Equal(expectedResult, result);
        }

        [InlineData(0.2, 2.2, 5.5, true)]
        [InlineData(1, -2.7, 5.3, false)]
        [InlineData(2.3, 2.3, 2.3, true)]
        [InlineData(25, 2, 30, false)]
        [InlineData(25.3, 2.7, 30.9, false)]
        [Theory]
        public void IsBetweenDoubleTest(double min, double value, double max, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsBetween(min, value, max);
            // Act
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-10, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(Int32.MinValue, false)]
        [InlineData(Int32.MaxValue, true)]
        [Theory]
        public void IsPositiveIntTest(int value, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsPositive(value);
            // Act
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-10.2, false)]
        [InlineData(0.0, false)]
        [InlineData(1.7, true)]
        [InlineData(Double.MinValue, false)]
        [InlineData(Double.MaxValue, true)]
        [Theory]
        public void IsPositiveDoubleTest(double value, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsPositive(value);
            // Act
            Assert.Equal(expectedResult, result);
        }

        [InlineData(0, 10, false)]
        [InlineData(1, 0, true)]
        [InlineData(5,5, true)]
        [InlineData(-2, -5, true)]
        [InlineData(-2, -2, true)]
        [InlineData(Int32.MaxValue, Int32.MinValue, true)]
        [InlineData(Int32.MinValue, Int32.MaxValue, false)]
        [InlineData(Int32.MinValue + 1, Int32.MinValue, true)]
        [Theory]
        public void IsGreaterOrEqualThanIntTest(int value, int min, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsGreaterOrEqualThan(value, min);
            // Act
            Assert.Equal(expectedResult, result);
        }

        [InlineData(0.2, 10.7, false)]
        [InlineData(1.3, 0.0, true)]
        [InlineData(5.5, 5.5, true)]
        [InlineData(-2.1, -5.3, true)]
        [InlineData(-2.3, -2.3, true)]
        [InlineData(Double.MaxValue, Double.MinValue, true)]
        [InlineData(Double.MinValue, Double.MaxValue, false)]
        [InlineData(Double.MinValue + 1, Double.MinValue, true)]
        [Theory]
        public void IsGreaterOrEqualThanDoubleTest(double value, double min, bool expectedResult)
        {
            // Assert
            bool result = Validators.IsGreaterOrEqualThan(value, min);
            // Act
            Assert.Equal(expectedResult, result);
        }
    }
}
