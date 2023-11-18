namespace NeedlemanWunsch.Services;

public class Compute : ICompute
{
    private int GapPernalty = -1;

    public int[,] CreateMatrix(int xSize, int ySize)
    {
        var matrix = new int[xSize, ySize];

        for (int i = 0; i < xSize; i++) matrix[0, i] = i * GapPernalty;
        for (int j = 0; j < ySize; j++) matrix[j, 0] = j * GapPernalty;

        return matrix;
    }

    public int ComputeBestValue(int[,] matrix, int x, int y, bool match = false)
    {
        int val1;

        if (match) val1 = matrix[x - 1, y - 1] - GapPernalty;
        else val1 = matrix[x - 1, y - 1] + GapPernalty;
        int val2 = matrix[x - 1, y] + GapPernalty;
        int val3 = matrix[x, y - 1] + GapPernalty;

        if (val1 >= val2 && val1 >= val3) return val1; 
        if (val2 >= val1 && val2 >= val3) return val2; 
        if (val3 >= val1 && val3 >= val2) return val3; 
        throw new Exception("Error in comparisson");
    }

    public string[] FindBestAlligment(int[,] matrix, List<char> x, List<char> y, int xSize, int ySize)
    {
        string AligmentA = "";
        string AligmentB = "";
        int i = xSize;
        int j = ySize;

        while (i > 0 || j > 0)
        {     
            if (i > 0 && j > 0 && matrix[i, j] == (matrix[i - 1, j - 1] + ((x[i - 1] == y[j - 1])?-GapPernalty:GapPernalty)))
            {
                AligmentA += x[i - 1];
                AligmentB += y[j - 1];
                i--;
                j--;
            }
            else if (i > 0 && matrix[i, j] == matrix[i - 1, j] + GapPernalty)
            {
                AligmentA += x[i - 1];
                AligmentB += '-';
                i--;
            }
            else
            {
                AligmentA += '-';
                AligmentB += y[j - 1];
                j--;
            }
        }

        return new string[] { AligmentA, AligmentB };
    }
}