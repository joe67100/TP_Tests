using CreditApp;

namespace CreditAppTest
{
    public class ConsoleOutputTests
    {
        [Theory]
        [InlineData("Buongiorno")]
        public void WriteShouldWriteMessageToConsole(string message)
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            ConsoleOutput.Write(message);

            // Assert
            string consoleOutput = stringWriter.ToString().Trim();
            Assert.Equal(message, consoleOutput);
        }
    }
}
