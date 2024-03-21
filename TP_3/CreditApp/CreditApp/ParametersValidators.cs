using System.Globalization;

namespace CreditApp
{
    public static class ParametersValidators
    {
        public static bool ValidateLoanAmount(double loanAmount)
        {
            return loanAmount >= 50000;
        }

        public static bool ValidateDuration(int duration)
        {
            int minDuration = 9 * 12;
            int maxDuration = 25 * 12;

            return duration >= minDuration && duration <= maxDuration;
        }

        public static bool ValidateNominalRate(double nominalRate)
        {
            return nominalRate > 0;
        }

        public static bool ValidateArgsLength(string[] args)
        {
            if (args.Length != 3)
            {
                return false;
            }
            return true;
        }

        public static (double loanAmount, int duration, double nominalRate, bool success) TryParseParameters(string[] args)
        {
            bool successLoanAmount = double.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double loanAmount);
            bool successDuration = int.TryParse(args[1], out int duration);
            bool successNominalRate = double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double nominalRate);

            bool success = successLoanAmount && successDuration && successNominalRate;

            return (loanAmount, duration, nominalRate, success);
        }


        public static bool ValidateParameters(string[] args)
        {
            if (!ValidateArgsLength(args))
            {
                Console.WriteLine("Veuillez fournir trois paramètres : le montant du prêt, la durée et le taux nominal.");
                return false;
            }

            var (loanAmount, duration, nominalRate, success) = TryParseParameters(args);

            if (!success)
            {
                Console.WriteLine("Les paramètres fournis ne sont pas valides. Veuillez vérifier les critères.");
                return false;
            }

            if (!ValidateLoanAmount(loanAmount) || !ValidateDuration(duration) || !ValidateNominalRate(nominalRate))
            {
                Console.WriteLine("Les paramètres fournis ne sont pas valides. Veuillez vérifier les critères.");
                return false;
            }

            return true;
        }
    }
}
