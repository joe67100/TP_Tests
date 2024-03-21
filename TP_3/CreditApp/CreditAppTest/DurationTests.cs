using CreditApp;

namespace CreditAppTest
{
    public class DurationTests
    {
        [InlineData(107)]
        [InlineData(301)]
        [Theory]
        public void ExceptionThrownIfDurationValueNotBetween108And300Int(int value)
        {
            // Arrange/Act
            var exception = Assert.Throws<ArgumentException>(() => new Duration(value));
            // Assert
            Assert.Equal("Duration has to be between 108 and 300", exception.Message);
        }

        [InlineData(108)]
        [InlineData(300)]
        [Theory]
        public void DurationValueInitializedIfDurationValueBetween108And300Int(int value)
        {
            // Arrange/Act
            var duration = new Duration(value);
            // Assert
            Assert.Equal(value, duration.DurationValue);
        }
    }
}
