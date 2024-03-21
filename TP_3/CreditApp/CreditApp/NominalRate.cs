using CreditApp.Interfaces;
using System.Numerics;

namespace CreditApp
{
    public class NominalRate : IValueObject
    {
        public double NominalRateValue { get; private set; }

        public NominalRate(double value)
        {
            Validate(value);
            NominalRateValue = value;
        }

        public void Validate<T>(T value)
            where T : INumber<T>
        {
            if (!Validators.IsPositive(value))
            {
                throw new ArgumentException("Nominal rate must be a positive value.");
            }
        }
    }
}
