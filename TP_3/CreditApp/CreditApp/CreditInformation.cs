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

        public double[] GetMonthlyLoanPayment()
        {
            double[] monthlyLoanPayments = new double[Duration.DurationValue];
            double monthlyPayment = GetMonthlyPayment();
            double remainingLoan = Loan.LoanValue;

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                double interestPayment = remainingLoan * NominalRatePercent / 12;
                double loanPayment = monthlyPayment - interestPayment;
                monthlyLoanPayments[i] = Math.Round(loanPayment, 2, MidpointRounding.AwayFromZero);
                remainingLoan -= loanPayment;
            }
            return monthlyLoanPayments;
        }

        public double[] GetMonthlyInterestPayment()
        {
            double[] monthlyInterestPayments = new double[Duration.DurationValue];
            double remainingLoan = Loan.LoanValue;

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                double interestPayment = remainingLoan * NominalRatePercent / 12;
                monthlyInterestPayments[i] = Math.Round(interestPayment, 2, MidpointRounding.AwayFromZero);
                remainingLoan -= (GetMonthlyPayment() - interestPayment);
            }
            return monthlyInterestPayments;
        }

        public double[] GetMonthlyRemainingDueLoan()
        {
            double[] remainingDueLoan = new double[Duration.DurationValue];
            double totalDueLoan = GetTotalDueLoan();

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                totalDueLoan -= GetMonthlyPayment();
                remainingDueLoan[i] = Math.Round(totalDueLoan, 2, MidpointRounding.AwayFromZero);
            }
            return remainingDueLoan;
        }
    }
}
