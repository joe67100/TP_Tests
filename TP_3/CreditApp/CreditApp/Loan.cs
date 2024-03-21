using CreditApp.Interfaces;
using System;
using System.Numerics;

namespace CreditApp
{
    public class Loan : IValueObject
    {
        public double LoanValue { get; private set; }

        public Loan(double value)
        {
            Validate(value);
            LoanValue = value;
        }

        public void Validate<T>(T value) 
            where T : INumber<T>
        {
            if (!Validators.IsGreaterOrEqualThan(value, (T)Convert.ChangeType(50000, typeof(T))))
            {
                throw new ArgumentException("Value must be greater or equal to 50,000");
            }
        }
    }
}
