namespace NeedlemanWunsch.Services;

interface ICompute 
{
    public int[,] CreateMatrix(int xSize, int ySize);
    public int ComputeBestValue(int[,] matrix, int x, int y, bool match = false);
    public string[] FindBestAlligment(int[,] matrix, List<char> x, List<char> y, int xSize, int ySize);
}