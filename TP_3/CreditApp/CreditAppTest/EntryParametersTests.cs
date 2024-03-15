using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CreditAppTest
{
    public class EntryParametersTests
    {
        [Theory]
        [InlineData("Arg1", "Arg2")]
        public void CheckIfArgsAreSet(string arg1, string arg2)
        {
            // Arrange
            string[] args = { arg1, arg2 };
            CommandLineArguments.SetArgs([arg1, arg2]);

            // Act
            string[] getArgs = CommandLineArguments.Args;

            // Assert
            Assert.Equal(getArgs, args);
        }

    }
}