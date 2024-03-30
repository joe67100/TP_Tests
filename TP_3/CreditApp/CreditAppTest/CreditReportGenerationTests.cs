using CreditApp.Domain;

namespace CreditAppTest
{
    public class CreditReportGenerationTests
    {
        [Theory]
        [InlineData("2022-01-05T14:57:12", "credit_recap_20220105_145712.csv")]
        [InlineData("1990-02-22T00:00:38", "credit_recap_19900222_000038.csv")]
        public void CheckIfGetFileNameReturnsCorrectFileName(DateTime date, string expectedFileName)
        {
            // Arrange
            CreditInformation creditInformation = new CreditInformation(new(70000), new(150), new(3));
            CreditReportGeneration creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            string fileName = creditReportGeneration.GetFileName(date);

            // Assert
            Assert.Equal(expectedFileName, fileName);
        }

        [Theory]
        [InlineData(70000, 150, 3, "Coût total crédit (€);84029,84;Durée (mois);150;Taux (%);3")]
        [InlineData(90000, 250, 5, "Coût total crédit (€);145040,89;Durée (mois);250;Taux (%);5")]
        public void CheckIfHeaderContainsCorrectInformation(double loanValue, int durationValue, double nominalRateValue, string expectedHeader)
        {
            // Arrange
            CreditInformation creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            CreditReportGeneration creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            string header = creditReportGeneration.GetHeader();

            // Assert
            Assert.Equal(expectedHeader, header);
        }

        [InlineData(300000, 108, 4.15, "17;2426,38;907,11;3333,49;303347,62", 17)]
        [InlineData(122000, 108, 1.5, "1;1055,8;152,5;1208,3;129288,05", 1)]
        [Theory]
        public void CheckIfGetCreditDataReturnsCorrectInformation(double loanValue, int durationValue, double nominalRateValue, string expectedData, int monthToCheck)
        {
            // Arrange
            CreditInformation creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            CreditReportGeneration creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            var data = creditReportGeneration.GetCreditData().Skip(monthToCheck - 1).First();

            // Assert
            Assert.Equal(expectedData, data);
        }

        [InlineData(300000, 108, 4.15, "17;2426,38;907,11;3333,49;303347,62", 17)]
        [Theory]
        public void CheckIfReportIsGeneratedWithCorrectValues(double loanValue, int durationValue, double nominalRateValue, string expectedData, int monthToCheck)
        {
            // Arrange
            CreditInformation creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            CreditReportGeneration creditReportGeneration = new CreditReportGeneration(creditInformation);
            creditReportGeneration.FileName = "correct_values_tests.csv";

            // Act
            creditReportGeneration.GenerateReport();
            List<string> lines = File.ReadLines(creditReportGeneration.FileName).ToList();

            // Assert
            Assert.Equal(expectedData, lines[monthToCheck + 2]); // +2 to skip the header and subheader

            // Cleanup
            File.Delete(creditReportGeneration.FileName);
        }
    }
}
