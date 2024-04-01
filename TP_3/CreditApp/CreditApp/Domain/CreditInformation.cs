using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class CreditInformation(Loan loan, Duration duration, NominalRate nominalRate) : ICreditInformation
    {
        public Loan Loan { get; } = loan;
        public Duration Duration { get; } = duration;
        public NominalRate NominalRate { get; } = nominalRate;
        public double NominalRatePercent => NominalRate.NominalRateValue / 100.0;

        public double GetMonthlyPayment()
        {
            return Loan.LoanValue * (NominalRatePercent / 12) / (1 - Math.Pow(1 + NominalRatePercent / 12, -Duration.DurationValue));
        }

        public double GetTotalDueLoan()
        {
            return GetMonthlyPayment() * Duration.DurationValue;
        }

        public double[] GetMonthlyCapitalPayment()
        {
            double[] monthlyCapitalPayments = new double[Duration.DurationValue];
            double monthlyPayment = GetMonthlyPayment();
            double remainingLoan = Loan.LoanValue;

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                double interestPayment = remainingLoan * NominalRatePercent / 12;
                double loanPayment = monthlyPayment - interestPayment;
                monthlyCapitalPayments[i] = loanPayment;
                remainingLoan -= loanPayment;
            }
            return monthlyCapitalPayments;
        }

        public double[] GetCumulativeMonthlyCapitalPayment()
        {
            double[] monthlyCapitalPayments = GetMonthlyCapitalPayment();
            double[] cumulativemonthlyCapitalPayments = new double[monthlyCapitalPayments.Length];
            double cumulativePayment = 0;

            for (int i = 0; i < monthlyCapitalPayments.Length; i++)
            {
                cumulativePayment += monthlyCapitalPayments[i];
                cumulativemonthlyCapitalPayments[i] = cumulativePayment;
            }

            return cumulativemonthlyCapitalPayments;
        }

        public double[] GetMonthlyInterestPayment()
        {
            double[] monthlyInterestPayments = new double[Duration.DurationValue];
            double remainingLoan = Loan.LoanValue;

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                double interestPayment = remainingLoan * NominalRatePercent / 12;
                monthlyInterestPayments[i] = interestPayment;
                remainingLoan -= GetMonthlyPayment() - interestPayment;
            }
            return monthlyInterestPayments;
        }

        public double[] GetRemainingDueLoan()
        {
            double[] remainingDueLoan = new double[Duration.DurationValue];
            double totalDueLoan = GetTotalDueLoan();

            for (int i = 0; i < Duration.DurationValue; i++)
            {
                totalDueLoan -= GetMonthlyPayment();
                remainingDueLoan[i] = totalDueLoan;
            }
            return remainingDueLoan;
        }
        public double[] GetRemainingCapitalDue()
        {
            double[] monthlyCapitalPayments = GetMonthlyCapitalPayment();
            double[] remainingLoanAfterMonthlyCapitalPayment = new double[monthlyCapitalPayments.Length];
            double remainingLoan = Loan.LoanValue;

            for (int i = 0; i < monthlyCapitalPayments.Length; i++)
            {
                remainingLoan -= monthlyCapitalPayments[i];
                remainingLoanAfterMonthlyCapitalPayment[i] = remainingLoan;
            }

            return remainingLoanAfterMonthlyCapitalPayment;
        }
    }
}
