using CreditApp.Interfaces;

namespace CreditApp
{
    public class CreditInformation : ICreditInformation
    {
        public Loan Loan { get; }
        public Duration Duration { get; }
        public NominalRate NominalRate { get; }

        public CreditInformation(Loan loan, Duration duration, NominalRate nominalRate)
        {
            Loan = loan;
            Duration = duration;
            NominalRate = nominalRate;
        }
    }
}
