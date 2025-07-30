namespace Algoritm;

public static class MatrixPrinter
{
    public static void PrintMatrix<T>(T[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine($"[{string.Join(", ", matrix[i])}]");
        }
    }
}