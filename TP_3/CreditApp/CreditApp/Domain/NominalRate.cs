using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class NominalRate
    {
        public double NominalRateValue { get; private set; }

        public NominalRate(double value)
        {
            if (!Validators.IsPositive(value))
            {
                throw new ArgumentException("Nominal rate must be a positive value.");
            }
            NominalRateValue = value;
        }
    }
}
