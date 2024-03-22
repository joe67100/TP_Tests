using CreditApp.Interfaces;

namespace CreditApp
{
    public class Duration : IValueObject<int>
    {
        public int DurationValue { get; private set; }

        public Duration(int value)
        {
            Validate(value);
            DurationValue = value;
        }

        public void Validate(int value)
        {
            if (!Validators.IsBetween(108, value, 300))
            {
                throw new ArgumentException("Duration has to be between 108 and 300");
            }
        }
    }
}
