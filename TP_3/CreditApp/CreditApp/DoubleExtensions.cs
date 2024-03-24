namespace CreditApp
{
    public static class DoubleExtensions
    {
        public static double Round(this double value, int digits = 2)
        {
            return Math.Round(value, digits, MidpointRounding.AwayFromZero);
        }
    }
}

