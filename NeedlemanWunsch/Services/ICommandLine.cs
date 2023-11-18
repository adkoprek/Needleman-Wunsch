namespace NeedlemanWunsch.Services;

interface ICommandLine
{
    public List<char>[] ParseArgs(string[] args);
}