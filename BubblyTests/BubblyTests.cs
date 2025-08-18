// <copyright file="BubblyTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BubblyTest;

using Algorithm;
using FluentAssertions;
using Xunit;

public sealed class BubblyTests
{
    private readonly Random _rnd = new Random();

    private int[][] GenerateRandomIntMatrix()
    {
        var rows = this._rnd.Next(1, 11);
        var cols = this._rnd.Next(1, 11);
        var matrix = new int[rows][];
        for (var i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
            for (var j = 0; j < cols; j++)
            {
                matrix[i][j] = this._rnd.Next(1, 101);
            }
        }

        return matrix;
    }

    private string[][] GenerateRandomStringMatrix()
    {
        var rows = this._rnd.Next(1, 11);
        var cols = this._rnd.Next(1, 11);
        var matrix = new string[rows][];
        for (var i = 0; i < rows; i++)
        {
            matrix[i] = new string[cols];
            for (var j = 0; j < cols; j++)
            {
                matrix[i][j] = this.RandomString(this._rnd.Next(1, 11));
            }
        }

        return matrix;
    }

    private string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        var stringChars = new char[length];
        for (var i = 0; i < length; i++)
        {
            stringChars[i] = chars[this._rnd.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    private double[][] GenerateRandomDoubleMatrix(int rows, int cols)
    {
        var matrix = new double[rows][];
        for (var i = 0; i < rows; i++)
        {
            matrix[i] = new double[cols];
            for (var j = 0; j < cols; j++)
            {
                matrix[i][j] = Math.Round(this._rnd.NextDouble() * 100, 2);
            }
        }

        return matrix;
    }

    private static double Sum(double[] array) => array.Sum();

    private static int Sum(int[] array) => array.Sum();

    private static int Sum(string[] array) => array.Sum(s => s.Length);

    private static double Max(double[] array) => array.Max();

    private static int Max(int[] array) => array.Max();

    private static string Max(string[] array) => array.Max() ?? string.Empty;

    private static double Min(double[] array) => array.Min();

    private static int Min(int[] array) => array.Min();

    private static string Min(string[] array) => array.Min() ?? string.Empty;

    private static double FirstElement(double[] array) => array[0];

    private static int FirstElement(int[] array) => array[0];

    [Fact]
    public void Test_SortBySum_Double_Ascending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(5, 4);

        sorter.Sort(matrix, BubbleSort<double>.BySum());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeLessThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortBySum_Double_Descending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(5, 4);

        sorter.Sort(matrix, (a, b) => BubbleSort<double>.BySum()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeGreaterThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortByMax_Double_Ascending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(4, 3);

        sorter.Sort(matrix, BubbleSort<double>.ByMax());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            max1.Should().BeLessThanOrEqualTo(max2);
        }
    }

    [Fact]
    public void Test_SortByMax_Double_Descending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(4, 3);

        sorter.Sort(matrix, (a, b) => BubbleSort<double>.ByMax()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            max1.Should().BeGreaterThanOrEqualTo(max2);
        }
    }

    [Fact]
    public void Test_SortByMin_Double_Ascending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(6, 3);

        sorter.Sort(matrix, BubbleSort<double>.ByMin());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            min1.Should().BeLessThanOrEqualTo(min2);
        }
    }

    [Fact]
    public void Test_SortByMin_Double_Descending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(6, 3);

        sorter.Sort(matrix, (a, b) => BubbleSort<double>.ByMin()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            min1.Should().BeGreaterThanOrEqualTo(min2);
        }
    }

    [Fact]
    public void Test_SortByFirstElement_Double_Ascending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(4, 5);

        sorter.Sort(matrix, BubbleSort<double>.ByFirstElement());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var f1 = FirstElement(matrix[i]);
            var f2 = FirstElement(matrix[i + 1]);
            f1.Should().BeLessThanOrEqualTo(f2);
        }
    }

    [Fact]
    public void Test_SortByFirstElement_Double_Descending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(4, 5);

        sorter.Sort(matrix, (a, b) => BubbleSort<double>.ByFirstElement()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var f1 = FirstElement(matrix[i]);
            var f2 = FirstElement(matrix[i + 1]);
            f1.Should().BeGreaterThanOrEqualTo(f2);
        }
    }

    [Fact]
    public void Test_SortByLength_Double_Ascending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(5, 4);

        sorter.Sort(matrix, BubbleSort<double>.ByLength());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeLessThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortByLength_Double_Descending()
    {
        var sorter = new BubbleSort<double>();
        var matrix = this.GenerateRandomDoubleMatrix(5, 4);

        sorter.Sort(matrix, (a, b) => BubbleSort<double>.ByLength()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeGreaterThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortBySum_Double_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<double>();
        var original = this.GenerateRandomDoubleMatrix(6, 4);

        var ascending = original.Select(row => row.ToArray()).ToArray();
        var descending = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(ascending, BubbleSort<double>.BySum());
        sorter.Sort(descending, (a, b) => BubbleSort<double>.BySum()(b, a));

        for (var i = 0; i < ascending.Length; i++)
        {
            ascending[i].Should().BeEquivalentTo(descending[descending.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortByMax_Double_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<double>();
        var original = this.GenerateRandomDoubleMatrix(5, 4);

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<double>.ByMax());
        sorter.Sort(desc, (a, b) => BubbleSort<double>.ByMax()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortByMin_Double_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<double>();
        var original = GenerateRandomDoubleMatrix(6, 4);

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<double>.ByMin());
        sorter.Sort(desc, (a, b) => BubbleSort<double>.ByMin()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortBySum_Int_Ascending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, BubbleSort<int>.BySum());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeLessThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortBySum_Int_Descending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<int>.BySum()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeGreaterThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortByMax_Int_Ascending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, BubbleSort<int>.ByMax());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            max1.Should().BeLessThanOrEqualTo(max2);
        }
    }

    [Fact]
    public void Test_SortByMax_Int_Descending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<int>.ByMax()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            max1.Should().BeGreaterThanOrEqualTo(max2);
        }
    }

    [Fact]
    public void Test_SortByMin_Int_Ascending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, BubbleSort<int>.ByMin());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            min1.Should().BeLessThanOrEqualTo(min2);
        }
    }

    [Fact]
    public void Test_SortByMin_Int_Descending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<int>.ByMin()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            min1.Should().BeGreaterThanOrEqualTo(min2);
        }
    }

    [Fact]
    public void Test_SortByFirstElement_Int_Ascending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, BubbleSort<int>.ByFirstElement());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var f1 = FirstElement(matrix[i]);
            var f2 = FirstElement(matrix[i + 1]);
            f1.Should().BeLessThanOrEqualTo(f2);
        }
    }

    [Fact]
    public void Test_SortByFirstElement_Int_Descending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<int>.ByFirstElement()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var f1 = FirstElement(matrix[i]);
            var f2 = FirstElement(matrix[i + 1]);
            f1.Should().BeGreaterThanOrEqualTo(f2);
        }
    }

    [Fact]
    public void Test_SortByLength_Int_Ascending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, BubbleSort<int>.ByLength());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeLessThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortByLength_Int_Descending()
    {
        var sorter = new BubbleSort<int>();
        var matrix = this.GenerateRandomIntMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<int>.ByLength()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeGreaterThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortBySum_Int_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<int>();
        var original = this.GenerateRandomIntMatrix();

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<int>.BySum());
        sorter.Sort(desc, (a, b) => BubbleSort<int>.BySum()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortByMax_Int_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<int>();
        var original = this.GenerateRandomIntMatrix();

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<int>.ByMax());
        sorter.Sort(desc, (a, b) => BubbleSort<int>.ByMax()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortBySum_String_Ascending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, BubbleSort<string>.BySum());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeLessThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortBySum_String_Descending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<string>.BySum()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var sum1 = Sum(matrix[i]);
            var sum2 = Sum(matrix[i + 1]);
            sum1.Should().BeGreaterThanOrEqualTo(sum2);
        }
    }

    [Fact]
    public void Test_SortByMax_String_Ascending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, BubbleSort<string>.ByMax());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            string.Compare(max1, max2, StringComparison.Ordinal).Should().BeLessThanOrEqualTo(0);
        }
    }

    [Fact]
    public void Test_SortByMax_String_Descending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<string>.ByMax()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var max1 = Max(matrix[i]);
            var max2 = Max(matrix[i + 1]);
            string.Compare(max1, max2, StringComparison.Ordinal).Should().BeLessThanOrEqualTo(0);
        }
    }

    [Fact]
    public void Test_SortByMin_String_Ascending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, BubbleSort<string>.ByMin());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            string.Compare(min1, min2, StringComparison.Ordinal).Should().BeLessThanOrEqualTo(0);
        }
    }

    [Fact]
    public void Test_SortByMin_String_Descending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<string>.ByMin()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var min1 = Min(matrix[i]);
            var min2 = Min(matrix[i + 1]);
            string.Compare(min1, min2, StringComparison.Ordinal).Should().BeLessThanOrEqualTo(0);
        }
    }

    [Fact]
    public void Test_SortByLength_String_Ascending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, BubbleSort<string>.ByLength());

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeLessThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortByLength_String_Descending()
    {
        var sorter = new BubbleSort<string>();
        var matrix = this.GenerateRandomStringMatrix();

        sorter.Sort(matrix, (a, b) => BubbleSort<string>.ByLength()(b, a));

        for (var i = 0; i < matrix.Length - 1; i++)
        {
            var l1 = matrix[i].Length;
            var l2 = matrix[i + 1].Length;
            l1.Should().BeGreaterThanOrEqualTo(l2);
        }
    }

    [Fact]
    public void Test_SortBySum_String_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<string>();
        var original = this.GenerateRandomStringMatrix();

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<string>.BySum());
        sorter.Sort(desc, (a, b) => BubbleSort<string>.BySum()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }

    [Fact]
    public void Test_SortByMax_String_AscendingAndDescending_AreReverse()
    {
        var sorter = new BubbleSort<string>();
        var original = this.GenerateRandomStringMatrix();

        var asc = original.Select(row => row.ToArray()).ToArray();
        var desc = original.Select(row => row.ToArray()).ToArray();

        sorter.Sort(asc, BubbleSort<string>.ByMax());
        sorter.Sort(desc, (a, b) => BubbleSort<string>.ByMax()(b, a));

        for (var i = 0; i < asc.Length; i++)
        {
            asc[i].Should().BeEquivalentTo(desc[desc.Length - 1 - i]);
        }
    }
}
