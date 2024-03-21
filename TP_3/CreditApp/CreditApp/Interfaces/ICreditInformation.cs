namespace CreditApp.Interfaces
{
    internal interface ICreditInformation
    {
        double Loan { get; }
        int Duration { get; }
        double NominalRate { get; }
    }
}
