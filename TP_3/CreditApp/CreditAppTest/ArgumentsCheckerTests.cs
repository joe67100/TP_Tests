using CreditApp;
using System.Collections.Immutable;

namespace CreditAppTest
{
    public class ArgumentsCheckerTests
    {
        [InlineData(new string[] { "1", "2", "3" }, 3, true)]
        [InlineData(new string[] { }, 0, true)]
        [InlineData(new string[] { "1", "2" }, 10, false)]
        [Theory]
        public void IsArgumentsLengthValidString(string[] value, int expectedLength, bool expectedResult)
        {
            // Arrange
            ImmutableArray<string> immutableValue = ImmutableArray.Create(value);

            // Act
            bool result = ArgumentsChecker.IsArgumentsLengthValid(immutableValue, expectedLength);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(new int[] { 1, 2, 3 }, 3, true)]
        [InlineData(new int[] { }, 0, true)]
        [InlineData(new int[] { -1, 2 }, 10, false)]
        [Theory]
        public void IsArgumentsLengthValidInt(int[] value, int expectedLength, bool expectedResult)
        {
            // Arrange
            ImmutableArray<int> immutableValue = ImmutableArray.Create(value);

            // Act
            bool result = ArgumentsChecker.IsArgumentsLengthValid(immutableValue, expectedLength);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
