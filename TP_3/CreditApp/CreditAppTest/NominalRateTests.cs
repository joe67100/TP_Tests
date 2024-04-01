using CreditApp.Domain;

namespace CreditAppTest
{
    public class NominalRateTests
    {
        [InlineData(-1)]
        [InlineData(0)]
        [Theory]
        public void ExceptionThrownIfNominalRateValueNotPositiveInt(int value)
        {
            // Arrange/Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new NominalRate(value));
            // Assert
            Assert.Equal("Nominal rate must be a positive value.", exception.Message);
        }

        [InlineData(-1.0)]
        [InlineData(0.0)]
        [Theory]
        public void ExceptionThrownIfNominalRateValueNotPositiveDouble(double value)
        {
            // Arrange/Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new NominalRate(value));
            // Assert
            Assert.Equal("Nominal rate must be a positive value.", exception.Message);
        }
    }
}
