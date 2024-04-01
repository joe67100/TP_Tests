using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class Duration
    {
        public int DurationValue { get; private set; }

        public Duration(int value)
        {
            if (!Validators.IsBetween(108, value, 300))
            {
                throw new ArgumentException("Duration has to be between 108 and 300");
            }
            DurationValue = value;
        }
    }
}
