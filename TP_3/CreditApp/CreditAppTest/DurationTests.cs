using CreditApp.Domain;

namespace CreditAppTest
{
    public class DurationTests
    {
        public static IEnumerable<object[]> ValidDurationValues => new List<object[]>
        {
            new object[] { 108 },
            new object[] { 300 },
            new object[] { 250 },
        };

        [InlineData(107)]
        [InlineData(301)]
        [InlineData(-100)]
        [Theory]
        public void ExceptionThrownIfDurationValueNotBetween108And300(int value)
        {
            // Arrange/Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Duration(value));
            // Assert
            Assert.Equal("Duration has to be between 108 and 300", exception.Message);
        }

        [MemberData(nameof(ValidDurationValues))]
        [Theory]
        public void ExceptionNotThrownIfDurationValueBetween108And300(int value)
        {
            // Arrange/Act
            Exception exception = Record.Exception(() => new Duration(value));
            // Assert
            Assert.Null(exception);
        }

        [MemberData(nameof(ValidDurationValues))]
        [Theory]
        public void DurationValueInitializedIfDurationValueBetween108And300(int value)
        {
            // Arrange/Act
            Duration duration = new Duration(value);
            // Assert
            Assert.Equal(value, duration.DurationValue);
        }
    }
}
