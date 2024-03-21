using CreditApp.Interfaces;
using System.Numerics;

namespace CreditApp
{
    public class Duration : IValueObject
    {
        public int DurationValue { get; private set; }

        public Duration(int value) {
            Validate(value);
            DurationValue = value;
        }

        public void Validate<T>(T value) 
            where T : INumber<T>
        {
            if (!Validators.IsBetween((T)Convert.ChangeType(108, typeof(T)), value, (T)Convert.ChangeType(300, typeof(T))))
            {
                throw new ArgumentException("Duration has to be between 108 and 300");
            }
        }
    }
}
