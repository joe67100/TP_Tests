using CreditApp.Domain;

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
            Exception exception = Record.Exception(() => new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue)));
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

        [InlineData(5.0, 0.05)]
        [InlineData(10.0, 0.1)]
        [InlineData(2, 0.02)]
        [Theory]
        public void NominalRatePercentReturnsCorrectValue(double nominalRateValue, double expectedPercent)
        {
            // Arrange
            CreditInformation creditInformation = new CreditInformation(new(52000), new(200), new(nominalRateValue));

            // Act
            double percent = creditInformation.NominalRatePercent;

            // Assert
            Assert.Equal(expectedPercent, percent);
        }

        [InlineData(200000, 180, 2, 1287.02)]
        [InlineData(50000.01, 108, 1.72, 500.05)]
        [InlineData(100000, 108, 1.5, 990.41)]
        [Theory]
        public void MonthlyPaymentIsCorrect(double loanValue, int durationValue, double nominalRateValue, double expectedMonthlyPayment)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));
            // Act
            double monthlyPayment = creditInformation.GetMonthlyPayment();
            // Assert
            Assert.Equal(expectedMonthlyPayment, monthlyPayment, 2);
        }

        [InlineData(100000, 200, 3, 127197.08)]
        [InlineData(690000, 280, 1.7, 836355.95)]
        [Theory]
        public void TotalDueLoanIsCorrect(double loanValue, int durationValue, double nominalRateValue, double expectedTotalDueLoan)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));
            // Act
            double totalDueLoan = creditInformation.GetTotalDueLoan();
            // Assert
            Assert.Equal(expectedTotalDueLoan, totalDueLoan, 2);
        }

        // Go to a defined month and check if the LoanPayment is correct
        [InlineData(200000, 180, 2, 180, 1284.88)]
        [InlineData(50000.01, 108, 1.72, 12, 435.19)]
        [InlineData(100000, 200, 3, 20, 404.74)]
        [Theory]
        public void GetMonthlyLoanPaymentIsCorrect(double loanValue, int durationValue, double nominalRateValue, int monthIndex, double expectedMonthlyLoanPayment)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));

            // Act
            double[] monthlyLoanPayments = creditInformation.GetMonthlyLoanPayment();

            // Assert
            Assert.Equal(expectedMonthlyLoanPayment, monthlyLoanPayments[monthIndex - 1], 2); // Ajustement car index commence � 0 donc monthlyLoanPayments[12] correspond au 13�me mois
        }

        // Go to a defined month and check if the InterestPayment is correct
        [InlineData(200000, 180, 2, 180, 2.2)]
        [InlineData(50000.01, 108, 1.72, 12, 64.86)]
        [InlineData(100000, 200, 3, 20, 231.24)]
        [Theory]
        public void GetMonthlyInterestPaymentIsCorrect(double loanValue, int durationValue, double nominalRateValue, int monthIndex, double expectedMonthlyInterestPayment)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));

            // Act
            double[] monthlyInterestPayments = creditInformation.GetMonthlyInterestPayment();

            // Assert
            Assert.Equal(expectedMonthlyInterestPayment, monthlyInterestPayments[monthIndex - 1], 0);
        }

        [InlineData(200000, 180, 2, 180)]
        [InlineData(50000.01, 108, 1.72, 5)]
        [InlineData(100000, 200, 3, 1)]
        [Theory]
        public void MonthlyPaymentIsSumOfLoanAndInterestPayments(double loanValue, int durationValue, double nominalRateValue, int monthIndex)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));

            // Act
            double monthlyPayment = creditInformation.GetMonthlyPayment();
            double[] monthlyLoanPayments = creditInformation.GetMonthlyLoanPayment();
            double[] monthlyInterestPayments = creditInformation.GetMonthlyInterestPayment();

            // Assert
            Assert.Equal(monthlyPayment, monthlyLoanPayments[monthIndex - 1] + monthlyInterestPayments[monthIndex - 1], 2);
        }

        [InlineData(200000, 180, 2, 8, 221366.99)]
        [InlineData(77500, 228, 2.4, 12, 91501.04)]
        [InlineData(87234, 200, 2, 200, 0)]
        [Theory]
        public void MonthlyRemainingDueLoanIsCorrectAtSpecificMonth(double loanValue, int durationValue, double nominalRateValue, int monthIndex, double expectedRemainingLoanValue)
        {
            // Arrange
            CreditInformation creditInformation = new(new(loanValue), new(durationValue), new(nominalRateValue));

            // Act
            double[] remainingDueLoan = creditInformation.GetMonthlyRemainingDueLoan();

            // Assert
            Assert.Equal(expectedRemainingLoanValue, remainingDueLoan[monthIndex - 1], 2);
        }
    }
}