using CreditApp.Interfaces;

namespace CreditApp
{
    public class CreditInformation : ICreditInformation
    {
        public double Loan { get; }
        public int Duration { get; }
        public double NominalRate { get; }

        public CreditInformation(double loan, int duration, double nominalRate)
        {
            Loan = loan;
            Duration = duration;
            NominalRate = nominalRate;
        }
    }
}
