namespace CreditAppTest
{
    public class ProgramTests
    {

        // Arrange
        public static IEnumerable<object[]> IncorrectArgs =>
            new List<object[]>
            {
                new object[] { new string[] { "1", "2" }},
                new object[] { new string[] { } },
                new object[] { new string[] { "1", "2", "3", "4" }},
                new object[] { new string[] { "49000", "100", "-3"}},
                new object[] { new string[] { "55000", "150", "-3"}},
                new object[] { new string[] { "10000", "150", "3"}},
                new object[] { new string[] { "80000", "50", "3"}},
            };

        // Arrrange
        public static IEnumerable<object[]> CorrectArgs =>
            new List<object[]>
            {
                new object[] { new string[] { "52000", "150", "2,52" } },
                new object[] { new string[] { "50000", "108", "3" } },
                new object[] { new string[] { "50000", "300", "0,01" } },
            };

        [MemberData(nameof(IncorrectArgs))]
        [Theory]
        public void ExceptionIsThrownIfArgsAreIncorrect(string[] args)
        {
            // Act/Assert
            Assert.ThrowsAny<Exception>(() => Program.Main(args));
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
