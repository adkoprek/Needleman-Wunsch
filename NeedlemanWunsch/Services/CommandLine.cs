namespace NeedlemanWunsch.Services;

public class CommandLine : ICommandLine
{
    public List<char>[] ParseArgs(string[] args)
    {
        var parsedArgs = new List<char>[2];
        int indexToWrite = 0;

        CheckArgs(args);

        foreach (var arg in args)
        {
            if (arg == "-x") indexToWrite = 0; 
            else if (arg == "-y") indexToWrite = 1;
            else 
            {
                var sequence = ParseSequence(arg);
                parsedArgs[indexToWrite] = sequence;
            }
        }

        return parsedArgs;
    }

    private void CheckArgs(string[] args)
    {
        if (!args.Contains("-x")) PrintException("ArgumentParseError \n Fist Sequenze not porovided \n Provide Argument with -a and then the uppercase letters");
        if (!args.Contains("-y")) PrintException("ArgumentParseError \n Second Sequenze not porovided \n Provide Argument with -b and then the uppercase letters");
    }

    private List<char> ParseSequence(string sequence)
    {
        var parsedSequence = new List<char>();
        foreach (char element in sequence)
        {
            if (char.IsUpper(element)) parsedSequence.Add(element);
            else PrintException("Sequence contains lower case letters");
        }
        return parsedSequence;
    }

    private void PrintException(string exception)
    {
        Console.Error.WriteLine(exception);
        Environment.Exit(-1);
    }
}