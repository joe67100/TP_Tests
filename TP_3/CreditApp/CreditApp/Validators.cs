using System.Numerics;

namespace CreditApp
{
    public static class Validators
    {
        public static bool IsBetween<T>(T min, T value, T max)
            where T : INumber<T>
        {
            return value >= min && value <= max;
        }

        public static bool IsPositive<T>(T value)
            where T : INumber<T>
        {
            return value > T.Zero;
        }

        public static bool IsGreaterOrEqualThan<T>(T value, T min)
            where T : INumber<T>
        {
            return value >= min;
        }
    }
}
