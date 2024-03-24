using CreditApp;

namespace CreditAppTest
{
    public class ProgramTests
    {
        // Arrrange
        public static IEnumerable<object[]> CorrectArgs =>
            new List<object[]>
            {
                new object[] { new string[] { "52000", "150", "2,52" } },
                new object[] { new string[] { "50000", "108", "3" } },
                new object[] { new string[] { "50000", "300", "0,01" } },
            };

        [InlineData(new string[] { }, "Invalid arguments length")]
        [InlineData(new string[] { "1", "2", "3", "4" }, "Invalid arguments length")]
        [InlineData(new string[] { "55000", "150", "-3" }, "Nominal rate must be a positive value.")]
        [InlineData(new string[] { "10000", "150", "3" }, "Value must be greater or equal to 50,000")]
        [InlineData(new string[] { "80000", "50", "3" }, "Duration has to be between 108 and 300")]
        [InlineData(new string[] { "zzz", "toto", "tata" }, "Invalid argument format.")]
        [InlineData(new string[] { "70000", "toto", "tata" }, "Invalid argument format.")]
        [InlineData(new string[] { "zzz", "200", "tata" }, "Invalid argument format.")]
        [Theory]
        public void CheckIfExceptionAreDisplayedInsideConsole(string[] args, string expectedErrorMessage)
        {
            // Arrange
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.Main(args);

            // Assert
            Assert.Contains(expectedErrorMessage, sw.ToString());
        }

        [MemberData(nameof(CorrectArgs))]
        [Theory]
        public void ExceptionIsNotThrownIfArgsAreCorrect(string[] args)
        {
            // Act
            var exception = Record.Exception(() => Program.Main(args));
            // Assert
            Assert.Null(exception);
        }
    }
}
