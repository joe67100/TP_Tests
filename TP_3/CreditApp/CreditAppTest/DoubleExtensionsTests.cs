using CreditApp;

namespace CreditAppTest
{
    public class DoubleExtensionsTests
    {
        [Theory]
        [InlineData(1.23456, 1.23)]
        [InlineData(1.236789, 1.24)]
        public void CheckIfRoudRoundsCorrectly(double value, double expectedValue)
        {
            // Act
            double actual = value.Round();

            // Assert
            Assert.Equal(expectedValue, actual);
        }
    }
}
