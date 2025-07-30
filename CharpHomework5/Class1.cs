using Algoritm;
using System;

class Program
{
    static void Main()
    {
        // Пример с int
        int[][] intMatrix = new int[][]
        {
            new int[] { 3, 1, 2 },
            new int[] { 2, 2, 2 },
            new int[] { 1, 1, 1 }
        };
        
        var intSorter = new BubbleShort<int>();
        // Сортируем по сумме элементов строки (просто identity для каждого int)
        Console.WriteLine("Исходная матрица:");
        MatrixPrinter.PrintMatrix(intMatrix);
        
        // Сортировка по сумме
        intSorter.Sort(intMatrix, intSorter.SumSelector<int>);
        Console.WriteLine("\nПо сумме (возрастание):");
        MatrixPrinter.PrintMatrix(intMatrix);
        
        // Пример с string
        string[][] stringMatrix = new string[][]
        {
            new string[] { "apple", "pear" },
            new string[] { "cat", "dog", "bee" },
            new string[] { "elephant" }
        };
        
        var stringSorter = new BubbleShort<string>();
        // Сортируем по сумме длины строк в каждой подстроке
        stringSorter.Sort(stringMatrix, s => s.Length);
        Console.WriteLine("\nSorted string matrix by total length of strings in row:");
        MatrixPrinter.PrintMatrix(stringMatrix);
        
        
    }
}