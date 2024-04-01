namespace CreditApp.Domain.Interfaces
{
    public interface ICreditInformation
    {
        Loan Loan { get; }
        Duration Duration { get; }
        NominalRate NominalRate { get; }
        double GetMonthlyPayment();
        double GetTotalDueLoan();
        double[] GetMonthlyCapitalPayment();
        double[] GetMonthlyInterestPayment();
        double[] GetRemainingDueLoan();
        double[] GetRemainingCapitalDue();
        double[] GetCumulativeMonthlyCapitalPayment();
    }
}
