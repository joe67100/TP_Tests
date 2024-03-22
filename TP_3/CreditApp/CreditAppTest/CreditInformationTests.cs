using CreditApp;

namespace CreditAppTest
{
    public class CreditInformationTests
    {
        [InlineData(50000, 108, 3.3)]
        [InlineData(Int32.MaxValue, 300, 2)]
        [Theory]
        public void CheckIfCreditObjectsAreProperlyPassedInsideCreditInformationConstructor(double loanValue, int durationValue, double nominalRateValue)
        {
            // Arrange
            Loan loan = new(loanValue);
            Duration duration = new(durationValue);
            NominalRate nominalRate = new(nominalRateValue);
            // Act
            CreditInformation creditInformation = new(loan, duration, nominalRate);

            // Assert
            Assert.Equal(loan.LoanValue, creditInformation.Loan.LoanValue);
            Assert.Equal(duration.DurationValue, creditInformation.Duration.DurationValue);
            Assert.Equal(nominalRate.NominalRateValue, creditInformation.NominalRate.NominalRateValue);
        }

        [InlineData(50000, 108, 3.3)]
        [InlineData(Int32.MaxValue, 300, 2)]
        [Theory]
        public void CreditInformationIsCreated(double loanValue, int durationValue, double nominalRateValue)
        {
            // Arrange/act
            var exception = Record.Exception(() => new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue)));
            // Assert
            Assert.Null(exception);
        }

        [InlineData(0, 108, 3.3)]
        [InlineData(50000, 0, 3.3)]
        [InlineData(50000, 108, -1)]
        [Theory]
        public void ExceptionIsThrownIfCreditInformationParametersAreIncorrect(double loanValue, int durationValue, double nominalRateValue)
        {
            // Arrange/act/assert
            Assert.ThrowsAny<ArgumentException>(() => new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue)));
        }
    }
}