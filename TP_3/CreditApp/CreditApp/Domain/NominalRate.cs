using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class NominalRate : IValueObject<double>
    {
        public double NominalRateValue { get; private set; }

        public NominalRate(double value)
        {
            Validate(value);
            NominalRateValue = value;
        }

        public void Validate(double value)
        {
            if (!Validators.IsPositive(value))
            {
                throw new ArgumentException("Nominal rate must be a positive value.");
            }
        }
    }
}
