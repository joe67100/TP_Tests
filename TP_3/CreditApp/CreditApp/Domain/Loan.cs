using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class Loan
    {
        public double LoanValue { get; private set; }

        public Loan(double value)
        {
            if (!Validators.IsGreaterOrEqualThan(value, 50000))
            {
                throw new ArgumentException("Value must be greater or equal to 50,000");
            }
            LoanValue = value;
        }
    }
}
