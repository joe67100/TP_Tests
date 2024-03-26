using CreditApp;
using System.Collections.Immutable;

namespace CreditAppTest
{
    public class ArgumentsUtilsTests
    {
        [InlineData(new object[] { }, false)]
        [InlineData(new object[] { -1, 2 }, false)]
        [InlineData(new object[] { "1", "2", "3" }, true)]
        [InlineData(new object[] { "1", "2" }, false)]
        [Theory]
        public void IsArgumentsLengthValidInt(object[] value, bool expectedResult)
        {
            // Arrange
            ImmutableArray<object> immutableValue = ImmutableArray.Create(value);

            // Act
            bool result = ArgumentsUtils.IsArgumentsLengthValid(immutableValue);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData("abc")]
        [InlineData("abc.45")]
        [Theory]
        public void ParseArgumentThrowsExceptionWhenArgumentIsInvalid(string arg)
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() => ArgumentsUtils.ParseArgument<int>(arg));
        }

        [InlineData("123", 123)]
        [InlineData("123,45", 123.45)]
        [Theory]
        public void ParseArgumentReturnsCorrectValue(string arg, double expected)
        {
            // Act
            double result = ArgumentsUtils.ParseArgument<double>(arg);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
