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

        [InlineData(200000, 180, 2, 1287.02)]
        [InlineData(50000.01, 108, 1.72, 500.05)]
        [Theory]
        public void MonthlyPaymentIsCorrect(double loanValue, int durationValue, double nominalRateValue, double expectedMonthlyPayment)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));
            // Act
            double monthlyPayment = creditInformation.GetMonthlyPayment();
            // Assert
            Assert.Equal(expectedMonthlyPayment, monthlyPayment);
        }

        [InlineData(100000, 200, 3, 127198)]
        [InlineData(690000, 280, 1.7, 836357.2)]
        [Theory]
        public void TotalDueLoanIsCorrect(double loanValue, int durationValue, double nominalRateValue, double expectedTotalDueLoan)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));
            // Act
            double totalDueLoan = creditInformation.GetTotalDueLoan();
            // Assert
            Assert.Equal(expectedTotalDueLoan, totalDueLoan);
        }
    }
}