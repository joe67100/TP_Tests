using System.Collections.Immutable;

namespace CreditApp
{
    public static class ArgumentsUtils
    {
        public static bool IsArgumentsLengthValid<T>(ImmutableArray<T> args)
        {
            return args.Length == 3;
        }

        public static T ParseArgument<T>(string arg) where T : IParsable<T>
        {
            try
            {
                return T.Parse(arg, null);
            }
            catch
            {
                Console.WriteLine("Error while trying to parse an argument");
                throw;
            }
        }
    }
}
