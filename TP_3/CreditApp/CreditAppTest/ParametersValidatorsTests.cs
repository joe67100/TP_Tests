using CreditApp;

namespace CreditAppTest
{
    public class ParametersValidatorsTests
    {
        [Theory]
        [InlineData(50000, true)]
        [InlineData(40000, false)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        public void TestValidateLoanAmount(double loanAmount, bool expected)
        {
            // Act
            var result = ParametersValidators.ValidateLoanAmount(loanAmount);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(108, true)]
        [InlineData(300, true)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(23, false)]
        public void TestValidateDuration(int duration, bool expected)
        {
            // Act
            var result = ParametersValidators.ValidateDuration(duration);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3.5, true)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        public void TestValidateNominalRate(double nominalRate, bool expected)
        {
            // Act
            var result = ParametersValidators.ValidateNominalRate(nominalRate);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "50000", "108", "3.5" }, true)]
        [InlineData(new string[] { "50000", "108" }, false)]
        [InlineData(new string[] { }, false)]
        public void TestValidateArgsLength(string[] args, bool expected)
        {
            // Act
            var result = ParametersValidators.ValidateArgsLength(args);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "50000", "108", "3.5" }, 50000, 108, 3.5, true)]
        [InlineData(new string[] { "abc", "108", "3.5" }, 0, 108, 3.5, false)]
        [InlineData(new string[] { "50000", "abc", "3.5" }, 50000, 0, 3.5, false)]
        [InlineData(new string[] { "50000", "108", "abc" }, 50000, 108, 0, false)]
        public void TestTryParseParameters(string[] args, double expectedLoanAmount, int expectedDuration, double expectedNominalRate, bool expectedSuccess)
        {
            // Act
            var (loanAmount, duration, nominalRate, success) = ParametersValidators.TryParseParameters(args);

            // Assert
            Assert.Equal(expectedLoanAmount, loanAmount);
            Assert.Equal(expectedDuration, duration);
            Assert.Equal(expectedNominalRate, nominalRate);
            Assert.Equal(expectedSuccess, success);
        }

        [Theory]
        [InlineData(new string[] { "50000", "108", "3.5" }, true)]
        [InlineData(new string[] { "120000", "150", "2"}, true)]
        [InlineData(new string[] { "40000", "108", "3.5" }, false)]
        [InlineData(new string[] { "50000", "300", "3.5" }, true)]
        [InlineData(new string[] { "50000", "108", "-1" }, false)]
        [InlineData(new string[] { "abc", "108", "3.5" }, false)]
        [InlineData(new string[] { "50000", "abc", "3.5" }, false)]
        [InlineData(new string[] { "50000", "108", "abc" }, false)]
        public void TestValidateParameters(string[] args, bool expected)
        {
            // Act
            var result = ParametersValidators.ValidateParameters(args);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
