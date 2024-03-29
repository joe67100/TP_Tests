﻿using CreditApp;

namespace CreditAppTest
{
    public class CsvCreatorTests
    {
        [InlineData("test1.csv", "test bonjour 1")]
        [Theory]
        public void CheckIfCsvFileIsCreatedWithCorrectInformation(string fileName, string expectedContent)
        {
            // Act
            CsvCreator.CreateCsvFile(fileName, writer => writer.Write(expectedContent));
            string actualContent = File.ReadAllText(fileName);

            // Assert
            Assert.True(File.Exists(fileName));
            Assert.Equal(expectedContent, actualContent);

            // Cleanup
            File.Delete(fileName);
        }
    }
}
