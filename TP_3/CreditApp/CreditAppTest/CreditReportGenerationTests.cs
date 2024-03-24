using CreditApp.Domain;

namespace CreditAppTest
{
    public class CreditReportGenerationTests
    {
        [Theory]
        [InlineData("2022-01-05T14:57:23", "credit_recap_20220105_145723.csv")]
        [InlineData("2024-03-24T10:00:23", "credit_recap_20240324_100023.csv")]
        [InlineData("1990-02-22T00:00:01", "credit_recap_19900222_000001.csv")]
        public void CheckIfGetFileNameReturnsCorrectFileName(DateTime date, string expectedFileName)
        {
            // Arrange
            var creditInformation = new CreditInformation(new(70000), new(150), new(3));
            var creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            var fileName = creditReportGeneration.GetFileName(date);

            // Assert
            Assert.Equal(expectedFileName, fileName);
        }

        [Theory]
        [InlineData(70000, 150, 3, "Coût total crédit (€);84029,84;Durée (mois);150;Taux (%);3")]
        [InlineData(80000, 200, 4, "Coût total crédit (€);109736,35;Durée (mois);200;Taux (%);4")]
        [InlineData(90000, 250, 5, "Coût total crédit (€);145040,89;Durée (mois);250;Taux (%);5")]
        public void CheckIfHeaderContainsCorrectInformation(double loanValue, int durationValue, double nominalRateValue, string expectedHeader)
        {
            // Arrange
            var creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            var creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            var header = creditReportGeneration.GetHeader();

            // Assert
            Assert.Equal(expectedHeader, header);
        }

        [InlineData("Mensualité;Amortissement (€) (capital);Intérêts (€);Coût mensualité (€);Restant dû (€)")]
        [Theory]
        public void CheckIfSubHeaderContainsCorrectInformation(string expectedSubheader)
        {
            // Arrange
            var creditInformation = new CreditInformation(new(70000), new(150), new(3));
            var creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            var subHeader = creditReportGeneration.GetSubHeader();

            // Assert
            Assert.Equal(expectedSubheader, subHeader);
        }

        [InlineData(300000, 108, 4.15, "17;2426,38;907,11;3333,49;303347,62", 17)]
        [InlineData(69690, 150, 2, "150;524,6;0,87;525,48;0", 150)]
        [InlineData(122000, 108, 1.5, "1;1055,8;152,5;1208,3;129288,05", 1)]
        [Theory]
        public void CheckIfGetCreditDataReturnsCorrectInformation(double loanValue, int durationValue, double nominalRateValue, string expectedData, int monthToCheck)
        {
            // Arrange
            var creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            var creditReportGeneration = new CreditReportGeneration(creditInformation);

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
            var creditInformation = new CreditInformation(new(loanValue), new(durationValue), new(nominalRateValue));
            var creditReportGeneration = new CreditReportGeneration(creditInformation);

            // Act
            creditReportGeneration.GenerateReport();
            var fileName = creditReportGeneration._fileName;
            var lines = File.ReadLines(fileName).ToList();

            // Assert
            Assert.Equal(expectedData, lines[monthToCheck + 2]); // +2 to skip the header and subheader

            // Cleanup
            File.Delete(fileName);
        }
    }
}
