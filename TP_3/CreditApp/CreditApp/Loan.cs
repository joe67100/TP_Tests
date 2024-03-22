using CreditApp.Interfaces;
using System;
using System.Numerics;

namespace CreditApp
{
    public class Loan : IValueObject<double>
    {
        public double LoanValue { get; private set; }

        public Loan(double value)
        {
            Validate(value);
            LoanValue = value;
        }

        public void Validate(double value)
        {
            if (!Validators.IsGreaterOrEqualThan(value, 50000))
            {
                throw new ArgumentException("Value must be greater or equal to 50,000");
            }
        }
    }
}
