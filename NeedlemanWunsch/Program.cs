using NeedlemanWunsch.Services;

namespace NeedlemanWunsch;

class Program 
{
    private static readonly ICommandLine CommandLineService = new CommandLine();
    private static readonly ICompute ComputeService = new Compute();

    static void Main(string[] args)
    {
        var parsedArgs = CommandLineService.ParseArgs(args);
        var matrix = ComputeService.CreateMatrix(parsedArgs[0].Count + 1, parsedArgs[1].Count + 1);

        for (int i = 1; i < parsedArgs[0].Count + 1; i++)
        {
            for (int j = 1; j < parsedArgs[1].Count + 1; j++)
            {
                matrix[j, i] = ComputeService.ComputeBestValue(matrix, j, i, parsedArgs[1][i - 1] == parsedArgs[0][j - 1]);
            }
        } 

        var bestAlligment = ComputeService.FindBestAlligment(matrix, parsedArgs[0], parsedArgs[1], parsedArgs[0].Count, parsedArgs[1].Count);
        Console.WriteLine($"Alligment 1: {bestAlligment[0]}");
        Console.WriteLine($"Alligment 2: {bestAlligment[1]}");
    }
}