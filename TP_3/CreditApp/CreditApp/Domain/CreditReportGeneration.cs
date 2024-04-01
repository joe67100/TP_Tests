using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class CreditReportGeneration
    {
        public ICreditInformation CreditInformation { get; private set; }

        public string FileName { get; set; }

        public CreditReportGeneration(ICreditInformation creditInformation)
        {
            CreditInformation = creditInformation;
            FileName = GetFileName(DateTime.Now);
        }

        public string GetFileName(DateTime date)
        {
            return $"credit_recap_{date:yyyyMMdd_HHmmss}.csv";
        }

        public string GetHeader()
        {
            return $"Coût total crédit (€);{CreditInformation.GetTotalDueLoan().Round()};Durée (mois);{CreditInformation.Duration.DurationValue};Taux (%);{CreditInformation.NominalRate.NominalRateValue}";
        }

        public string GetSubHeader()
        {
            return "Mensualité;Capital remboursé (€);Capital restant dû (€);Amortissement mensuel (€) (capital);Intérêts mensuels (€);Coût mensualité (€);Total restant dû (€)";
        }
        
        public IEnumerable<string> GetCreditData()
        {
            double[] monthlyCumulativeCapitalPayments = CreditInformation.GetCumulativeMonthlyCapitalPayment();
            double[] remainingCapitalDue = CreditInformation.GetRemainingCapitalDue();
            double[] monthlyCapitalPayments = CreditInformation.GetMonthlyCapitalPayment();
            double[] monthlyInterestPayments = CreditInformation.GetMonthlyInterestPayment();
            double[] remainingDueLoan = CreditInformation.GetRemainingDueLoan();

            for (int i = 0; i < CreditInformation.Duration.DurationValue; i++)
            {
                yield return $"{i + 1};{monthlyCumulativeCapitalPayments[i].Round()};{remainingCapitalDue[i].Round()};{monthlyCapitalPayments[i].Round()};{monthlyInterestPayments[i].Round()};{CreditInformation.GetMonthlyPayment().Round()};{Math.Abs(remainingDueLoan[i].Round())}";
            }
        }

        public void GenerateReport()
        {
            CsvCreator.CreateCsvFile(FileName, writer =>
            {
                writer.WriteLine(GetHeader());
                writer.WriteLine();
                writer.WriteLine(GetSubHeader());

                foreach (var line in GetCreditData())
                {
                    writer.WriteLine(line);
                }
            });
        }
    }
}