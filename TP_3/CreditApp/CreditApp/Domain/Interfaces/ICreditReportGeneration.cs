namespace CreditApp.Domain.Interfaces
{
    public interface ICreditReportGeneration
    {
        string GetFileName(DateTime date);
        string GetHeader();
        string GetSubHeader();
        IEnumerable<string> GetCreditData();
        void GenerateReport();
    }
}