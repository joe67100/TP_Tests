namespace CreditApp.Interfaces
{
    internal interface ICreditInformation
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
