using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class CreditReportGeneration : ICreditReportGeneration
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
            return "Mensualité;Amortissement (€) (capital);Intérêts (€);Coût mensualité (€);Restant dû (€)";
        }

        public IEnumerable<string> GetCreditData()
        {
            double[] monthlyLoanPayments = CreditInformation.GetMonthlyLoanPayment();
            double[] monthlyInterestPayments = CreditInformation.GetMonthlyInterestPayment();
            double[] remainingDueLoan = CreditInformation.GetMonthlyRemainingDueLoan();

            for (int i = 0; i < CreditInformation.Duration.DurationValue; i++)
            {
                yield return $"{i + 1};{monthlyLoanPayments[i].Round()};{monthlyInterestPayments[i].Round()};{CreditInformation.GetMonthlyPayment().Round()};{Math.Abs(remainingDueLoan[i].Round())}";
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