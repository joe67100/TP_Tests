using CreditApp.Interfaces;

namespace CreditApp
{
    public class CreditInformation : ICreditInformation
    {
        public Loan Loan { get; }
        public Duration Duration { get; }
        public NominalRate NominalRate { get; }
        private double NominalRatePercent => NominalRate.NominalRateValue / 100.0;

        public CreditInformation(Loan loan, Duration duration, NominalRate nominalRate)
        {
            Loan = loan;
            Duration = duration;
            NominalRate = nominalRate;
        }

        public double GetMonthlyPayment()
        {
            return Math.Round(Loan.LoanValue * (NominalRatePercent / 12) / (1 - Math.Pow((1 + NominalRatePercent / 12), -Duration.DurationValue)), 2, MidpointRounding.AwayFromZero);
        }

        public double GetTotalDueLoan()
        {
            return Math.Round(GetMonthlyPayment() * Duration.DurationValue, 2, MidpointRounding.AwayFromZero);
        }
    }
}
