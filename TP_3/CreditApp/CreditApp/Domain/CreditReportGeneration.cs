using CreditApp.Domain.Interfaces;

namespace CreditApp.Domain
{
    public class CreditReportGeneration : ICreditReportGeneration
    {
        private readonly ICreditInformation _creditInformation;
        public readonly string _fileName;

        public CreditReportGeneration(ICreditInformation creditInformation)
        {
            _creditInformation = creditInformation;
            _fileName = GetFileName(DateTime.Now);
        }

        public string GetFileName(DateTime date)
        {
            return $"credit_recap_{date:yyyyMMdd_HHmmss}.csv";
        }

        public string GetHeader()
        {
            return $"Coût total crédit (€);{_creditInformation.GetTotalDueLoan().Round()};Durée (mois);{_creditInformation.Duration.DurationValue};Taux (%);{_creditInformation.NominalRate.NominalRateValue}";
        }

        public string GetSubHeader()
        {
            return "Mensualité;Amortissement (€) (capital);Intérêts (€);Coût mensualité (€);Restant dû (€)";
        }

        public IEnumerable<string> GetCreditData()
        {
            double[] monthlyLoanPayments = _creditInformation.GetMonthlyLoanPayment();
            double[] monthlyInterestPayments = _creditInformation.GetMonthlyInterestPayment();
            double[] remainingDueLoan = _creditInformation.GetMonthlyRemainingDueLoan();

            for (int i = 0; i < _creditInformation.Duration.DurationValue; i++)
            {
                yield return $"{i + 1};{monthlyLoanPayments[i].Round()};{monthlyInterestPayments[i].Round()};{_creditInformation.GetMonthlyPayment().Round()};{Math.Abs(remainingDueLoan[i].Round())}";
            }
        }

        public void GenerateReport()
        {
            CsvCreator.CreateCsvFile(_fileName, writer =>
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