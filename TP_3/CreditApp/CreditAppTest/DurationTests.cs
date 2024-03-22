using CreditApp;

namespace CreditAppTest
{
    public class DurationTests
    {
        [InlineData(107)]
        [InlineData(301)]
        [InlineData(-100)]
        [Theory]
        public void ExceptionThrownIfDurationValueNotBetween108And300(int value)
        {
            // Arrange/Act
            var exception = Assert.Throws<ArgumentException>(() => new Duration(value));
            // Assert
            Assert.Equal("Duration has to be between 108 and 300", exception.Message);
        }

        [InlineData(108)]
        [InlineData(300)]
        [InlineData(250)]
        [Theory]
        public void ExceptionNotThrownIfDurationValueBetween108And300(int value)
        {
            // Arrange/Act
            var exception = Record.Exception(() => new Duration(value));
            // Assert
            Assert.Null(exception);
        }

        [InlineData(108)]
        [InlineData(300)]
        [InlineData(250)]
        [Theory]
        public void DurationValueInitializedIfDurationValueBetween108And300(int value)
        {
            // Arrange/Act
            var duration = new Duration(value);
            // Assert
            Assert.Equal(value, duration.DurationValue);
        }
    }
}
