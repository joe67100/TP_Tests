using CreditApp;

namespace CreditAppTest
{
    public class LoanTests
    {
        [InlineData(20000)]
        [InlineData(-10000)]
        [Theory]
        public void ExceptionThrownIfLoanValueLessThan50000Int(int value)
        {
            // Arrange/Act
            var exception = Assert.Throws<ArgumentException>(() => new Loan(value));
            // Assert
            Assert.Equal("Value must be greater or equal to 50,000", exception.Message);
        }

        [InlineData(50000)]
        [InlineData(Int32.MaxValue)]
        [Theory]
        public void LoanValueInitializedIfLoanValueGreaterOrEqualThan50000Int(int value)
        {
            // Arrange/Act
            var loan = new Loan(value);
            // Assert
            Assert.Equal(value, loan.LoanValue);
        }

        [InlineData(20000.23)]
        [InlineData(-10000.10)]
        [Theory]
        public void ExceptionThrownIfLoanValueLessThan50000Double(double value)
        {
            // Arrange/Act
            var exception = Assert.Throws<ArgumentException>(() => new Loan(value));
            // Assert
            Assert.Equal("Value must be greater or equal to 50,000", exception.Message);
        }

        [InlineData(50000.0)]
        [InlineData(Double.MaxValue)]
        [Theory]
        public void LoanValueInitializedIfLoanValueGreaterOrEqualThan50000Double(double value)
        {
            // Arrange/Act
            var loan = new Loan(value);
            // Assert
            Assert.Equal(value, loan.LoanValue);
        }
    }
}
