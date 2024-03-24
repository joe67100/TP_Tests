namespace CreditApp.Domain.Interfaces
{
    public interface ICreditInformation
    {
        Loan Loan { get; }
        Duration Duration { get; }
        NominalRate NominalRate { get; }
        double GetMonthlyPayment();
        double GetTotalDueLoan();
        double[] GetMonthlyLoanPayment();
        double[] GetMonthlyInterestPayment();
        double[] GetMonthlyRemainingDueLoan();
    }
}
