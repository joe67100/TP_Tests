public static class CommandLineArguments
{
    public static string[] Args { get; private set; }

    public static void SetArgs(string[] args)
    {
        Args = args;
    }
}
