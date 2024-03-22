using CreditApp;
using System.Collections.Immutable;

public class Program
{
    public static void Main(string[] args)
    {
        ImmutableArray<string> immutableArgs = ImmutableArray.Create(args);

        if (!ArgumentsUtils.IsArgumentsLengthValid(immutableArgs))
        {
            throw new ArgumentException("Invalid arguments length");
        }

        double loanValue = ArgumentsUtils.ParseArgument<double>(immutableArgs[0]);
        int durationValue = ArgumentsUtils.ParseArgument<int>(immutableArgs[1]);
        double nominalRateValue = ArgumentsUtils.ParseArgument<double>(immutableArgs[2]);

        Loan loan = new(loanValue);
        Duration duration = new(durationValue);
        NominalRate nominalRate = new(nominalRateValue);
        CreditInformation creditInformation = new(loan, duration, nominalRate);
    }
}