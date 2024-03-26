using CreditApp.Domain;

namespace CreditAppTest
{
    public class LoanTests
    {
        [InlineData(49999)]
        [InlineData(-10000)]
        [InlineData(Int32.MinValue)]
        [Theory]
        public void ExceptionThrownIfLoanValueLessThan50000Int(int value)
        {
            // Arrange/Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Loan(value));
            // Assert
            Assert.Equal("Value must be greater or equal to 50,000", exception.Message);
        }

        [InlineData(50000)]
        [InlineData(120000)]
        [InlineData(Int32.MaxValue)]
        [Theory]
        public void ExceptionNotThrownIfLoanValueGreaterOrEqualThan50000Int(int value)
        {
            // Arrange/Act
            Exception exception = Record.Exception(() => new Loan(value));
            // Assert
            Assert.Null(exception);
        }

        [InlineData(50000)]
        [InlineData(120000)]
        [InlineData(Int32.MaxValue)]
        [Theory]
        public void LoanValueInitializedIfLoanValueGreaterOrEqualThan50000Int(int value)
        {
            // Arrange/Act
            Loan loan = new Loan(value);
            // Assert
            Assert.Equal(value, loan.LoanValue);
        }

        [InlineData(20000.23)]
        [InlineData(-10000.10)]
        [Theory]
        public void ExceptionThrownIfLoanValueLessThan50000Double(double value)
        {
            // Arrange/Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Loan(value));
            // Assert
            Assert.Equal("Value must be greater or equal to 50,000", exception.Message);
        }

        [InlineData(50000.0)]
        [InlineData(120000.23)]
        [InlineData(Double.MaxValue)]
        [Theory]
        public void ExceptionNotThrownIfLoanValueGreaterOrEqualThan50000Double(double value)
        {
            // Arrange/Act
            Exception exception = Record.Exception(() => new Loan(value));
            // Assert
            Assert.Null(exception);
        }

        [InlineData(50000.0)]
        [InlineData(Double.MaxValue)]
        [Theory]
        public void LoanValueInitializedIfLoanValueGreaterOrEqualThan50000Double(double value)
        {
            // Arrange/Act
            Loan loan = new Loan(value);
            // Assert
            Assert.Equal(value, loan.LoanValue);
        }
    }
}
