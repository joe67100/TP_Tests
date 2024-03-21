using System.Collections.Immutable;

namespace CreditApp
{
    public static class ArgumentsChecker
    {
        public static bool IsArgumentsLengthValid<T>(ImmutableArray<T> args, int size)
        {
            return args.Length == size;
        }
    }
}
