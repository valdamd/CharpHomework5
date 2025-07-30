
using Xunit;
using Algoritm;
using Assert = Xunit.Assert;

namespace BubblyTest;

[TestFixture]
public class BubblyShortTest
{
    private readonly Random _rnd = new Random();
    
    // Вспомогательный метод для генерации случайной int-матрицы
    private int[][] GenerateRandomIntMatrix()
    {
        int rows = _rnd.Next(1, 11); // от 1 до 10 строк
        int cols = _rnd.Next(1, 11); // от 1 до 10 столбцов
        var matrix = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
            for (int j = 0; j < cols; j++)
                matrix[i][j] = _rnd.Next(1, 101); // числа от 1 до 100
        }
        return matrix;
    }

    // Вспомогательный метод для генерации случайной string-матрицы
    private string[][] GenerateRandomStringMatrix()
    {
        int rows = _rnd.Next(1, 11);
        int cols = _rnd.Next(1, 11);
        var matrix = new string[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new string[cols];
            for (int j = 0; j < cols; j++)
                matrix[i][j] = RandomString(_rnd.Next(1, 11)); // строки длиной от 1 до 10 символов
        }
        return matrix;
    }
    private string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
            stringChars[i] = chars[_rnd.Next(chars.Length)];
        return new string(stringChars);
    }

    private double[][] GenerateRandomDoubleMatrix(int rows, int cols)
    {
        var matrix = new double[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new double[cols];
            for (int j = 0; j < cols; j++)
            {
                // случайное число от 0.0 до 100.0
                matrix[i][j] = Math.Round(_rnd.NextDouble() * 100, 2);
            }
        }
        return matrix;
    }

    // [Test]
    // public void Test_SortBySum_Double()
    // {
    //     var bubble = new BubbleShort<double>();
    //     bubble.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    //
    //     var matrix = GenerateRandomDoubleMatrix(5, 4);
    //     bubble.Sort(matrix, bubble.SumSelector); // после правки сигнатуры
    //
    //     for (int i = 0; i < matrix.Length - 1; i++)
    //     {
    //         double sum1 = (double)bubble.SumSelector(matrix[i]);
    //         double sum2 = (double)bubble.SumSelector(matrix[i + 1]);
    //         Assert.That(sum1, Is.LessThanOrEqualTo(sum2));
    //     }
    //
    //
    // }
    
    [Fact]
    public void Test_SortByMax_Double()
    {
        var sorter = new BubbleShort<double>();
        sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);

        var matrix = GenerateRandomDoubleMatrix(4, 3);

        // Console.WriteLine("До сортировки:");
        // MatrixPrinter.PrintMatrix(matrix);

        sorter.Sort(matrix, sorter.MaxSelector);

        // Console.WriteLine("После сортировки:");
        // MatrixPrinter.PrintMatrix(matrix);

        for (int i = 0; i < matrix.Length - 1; i++)
        {
            double max1 = (double)sorter.MaxSelector(matrix[i]);
            double max2 = (double)sorter.MaxSelector(matrix[i + 1]);

            // Console.WriteLine($"Сравнение: max1 = {max1}, max2 = {max2}");
            Assert.True(max1 >= max2, $"Ожидалось: {max1} >= {max2}");
        }
    }
    
    
    // [Test]
    // public void Test_SortByMax_Double()
    // {
    //     var sorter = new BubbleShort<double>();
    //     sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    //
    //     var matrix = GenerateRandomDoubleMatrix(4, 3);
    //     sorter.Sort(matrix, sorter.MaxSelector);
    //
    //     for (int i = 0; i < matrix.Length - 1; i++)
    //     {
    //         double max1 = (double)sorter.MaxSelector(matrix[i]);
    //         double max2 = (double)sorter.MaxSelector(matrix[i + 1]);
    //         Console.WriteLine($"Сравнение: max1 = {max1}, max2 = {max2}");
    //         Assert.That(max1, Is.LessThanOrEqualTo(max2));
    //     }
    // }
    
    [Xunit.Theory]
[InlineData(BubbleShort<double>.SortDirection.Ascending)]
[InlineData(BubbleShort<double>.SortDirection.Descending)]
public void Test_SortBySum_Double(BubbleShort<double>.SortDirection direction)
{
    var sorter = new BubbleShort<double>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomDoubleMatrix(5, 4); // фиксированное количество столбцов
    sorter.Sort(matrix, sorter.SumSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        double sum1 = (double)sorter.SumSelector(matrix[i]);
        double sum2 = (double)sorter.SumSelector(matrix[i + 1]);
        if (direction == BubbleShort<double>.SortDirection.Ascending)
            Assert.True(sum1 <= sum2);
        else
            Assert.True(sum1 >= sum2);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<double>.SortDirection.Ascending)]
[InlineData(BubbleShort<double>.SortDirection.Descending)]
public void Test_SortByMin_Double(BubbleShort<double>.SortDirection direction)
{
    var sorter = new BubbleShort<double>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomDoubleMatrix(6, 3);
    sorter.Sort(matrix, sorter.MinSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        double min1 = (double)sorter.MinSelector(matrix[i]);
        double min2 = (double)sorter.MinSelector(matrix[i + 1]);
        if (direction == BubbleShort<double>.SortDirection.Ascending)
            Assert.True(min1 <= min2);
        else
            Assert.True(min1 >= min2);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<double>.SortDirection.Ascending)]
[InlineData(BubbleShort<double>.SortDirection.Descending)]
public void Test_SortByFirstElement_Double(BubbleShort<double>.SortDirection direction)
{
    var sorter = new BubbleShort<double>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomDoubleMatrix(4, 5); // минимум 1 элемент
    sorter.Sort(matrix, sorter.FirstElementSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        double f1 = (double)sorter.FirstElementSelector(matrix[i]);
        double f2 = (double)sorter.FirstElementSelector(matrix[i + 1]);
        if (direction == BubbleShort<double>.SortDirection.Ascending)
            Assert.True(f1 <= f2);
        else
            Assert.True(f1 >= f2);
    }
}

[Fact]
public void Test_SortBySum_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<double>();

    var original = GenerateRandomDoubleMatrix(6, 4);

    // Создаем копии
    var ascending = original.Select(row => row.ToArray()).ToArray();
    var descending = original.Select(row => row.ToArray()).ToArray();

    // Сортировка по возрастанию
    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    sorter.Sort(ascending, sorter.SumSelector);

    // Сортировка по убыванию
    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    sorter.Sort(descending, sorter.SumSelector);

    // Проверяем, что строки в обратном порядке
    for (int i = 0; i < ascending.Length; i++)
    {
        double[] rowAsc = ascending[i];
        double[] rowDesc = descending[descending.Length - 1 - i];
        Assert.Equal(rowAsc, rowDesc); // сравнение массивов
    }
}

   [Fact]
public void Test_SortByMin_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<double>();
    var original = GenerateRandomDoubleMatrix(6, 4);

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.MinSelector);

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    sorter.Sort(desc, sorter.MinSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByMax_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<double>();
    var original = GenerateRandomDoubleMatrix(5, 4);

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.MaxSelector);

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    sorter.Sort(desc, sorter.MaxSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByFirstElement_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<double>();
    var original = GenerateRandomDoubleMatrix(5, 4);

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.FirstElementSelector);

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    sorter.Sort(desc, sorter.FirstElementSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByLength_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<double>();
    var original = GenerateRandomDoubleMatrix(5, 4);

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.LengthSelector);

    sorter.SetSortDirection(BubbleShort<double>.SortDirection.Descending);
    sorter.Sort(desc, sorter.LengthSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Xunit.Theory]
[InlineData(BubbleShort<int>.SortDirection.Ascending)]
[InlineData(BubbleShort<int>.SortDirection.Descending)]
public void Test_SortBySum_Int(BubbleShort<int>.SortDirection direction)
{
    var sorter = new BubbleShort<int>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomIntMatrix();
    sorter.Sort(matrix, sorter.SumSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        int sum1 = (int)sorter.SumSelector(matrix[i]);
        int sum2 = (int)sorter.SumSelector(matrix[i + 1]);
        if (direction == BubbleShort<int>.SortDirection.Ascending)
            Assert.True(sum1 <= sum2);
        else
            Assert.True(sum1 >= sum2);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<int>.SortDirection.Ascending)]
[InlineData(BubbleShort<int>.SortDirection.Descending)]
public void Test_SortByMin_Int(BubbleShort<int>.SortDirection direction)
{
    var sorter = new BubbleShort<int>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomIntMatrix();
    sorter.Sort(matrix, sorter.MinSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        int min1 = (int)sorter.MinSelector(matrix[i]);
        int min2 = (int)sorter.MinSelector(matrix[i + 1]);
        if (direction == BubbleShort<int>.SortDirection.Ascending)
            Assert.True(min1 <= min2);
        else
            Assert.True(min1 >= min2);
    }
}
[Xunit.Theory]
[InlineData(BubbleShort<int>.SortDirection.Ascending)]
[InlineData(BubbleShort<int>.SortDirection.Descending)]
public void Test_SortByFirstElement_Int(BubbleShort<int>.SortDirection direction)
{
    var sorter = new BubbleShort<int>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomIntMatrix();
    sorter.Sort(matrix, sorter.FirstElementSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        int f1 = (int)sorter.FirstElementSelector(matrix[i]);
        int f2 = (int)sorter.FirstElementSelector(matrix[i + 1]);
        if (direction == BubbleShort<int>.SortDirection.Ascending)
            Assert.True(f1 <= f2);
        else
            Assert.True(f1 >= f2);
    }
}

[Fact]
public void Test_SortBySum_Int_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<int>();
    var original = GenerateRandomIntMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.SumSelector);

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Descending);
    sorter.Sort(desc, sorter.SumSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByMin_Int_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<int>();
    var original = GenerateRandomIntMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.MinSelector);

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Descending);
    sorter.Sort(desc, sorter.MinSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByMax_Int_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<int>();
    var original = GenerateRandomIntMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.MaxSelector);

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Descending);
    sorter.Sort(desc, sorter.MaxSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByFirstElement_Int_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<int>();
    var original = GenerateRandomIntMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.FirstElementSelector);

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Descending);
    sorter.Sort(desc, sorter.FirstElementSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByLength_Int_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<int>();
    var original = GenerateRandomIntMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.LengthSelector);

    sorter.SetSortDirection(BubbleShort<int>.SortDirection.Descending);
    sorter.Sort(desc, sorter.LengthSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}
[Xunit.Theory]
[InlineData(BubbleShort<string>.SortDirection.Ascending)]
[InlineData(BubbleShort<string>.SortDirection.Descending)]
public void Test_SortByMin_String(BubbleShort<string>.SortDirection direction)
{
    var sorter = new BubbleShort<string>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomStringMatrix();
    sorter.Sort(matrix, sorter.MinSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        string min1 = (string)sorter.MinSelector(matrix[i]);
        string min2 = (string)sorter.MinSelector(matrix[i + 1]);
        if (direction == BubbleShort<string>.SortDirection.Ascending)
            Assert.True(string.Compare(min1, min2) <= 0);
        else
            Assert.True(string.Compare(min1, min2) >= 0);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<string>.SortDirection.Ascending)]
[InlineData(BubbleShort<string>.SortDirection.Descending)]
public void Test_SortByFirstElement_String(BubbleShort<string>.SortDirection direction)
{
    var sorter = new BubbleShort<string>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomStringMatrix();
    sorter.Sort(matrix, sorter.FirstElementSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        string f1 = (string)sorter.FirstElementSelector(matrix[i]);
        string f2 = (string)sorter.FirstElementSelector(matrix[i + 1]);
        if (direction == BubbleShort<string>.SortDirection.Ascending)
            Assert.True(string.Compare(f1, f2) <= 0);
        else
            Assert.True(string.Compare(f1, f2) >= 0);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<string>.SortDirection.Ascending)]
[InlineData(BubbleShort<string>.SortDirection.Descending)]
public void Test_SortByLength_String(BubbleShort<string>.SortDirection direction)
{
    var sorter = new BubbleShort<string>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomStringMatrix();
    sorter.Sort(matrix, sorter.LengthSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        int l1 = (int)sorter.LengthSelector(matrix[i]);
        int l2 = (int)sorter.LengthSelector(matrix[i + 1]);
        if (direction == BubbleShort<string>.SortDirection.Ascending)
            Assert.True(l1 <= l2);
        else
            Assert.True(l1 >= l2);
    }
}
[Xunit.Theory]
[InlineData(BubbleShort<string>.SortDirection.Ascending)]
[InlineData(BubbleShort<string>.SortDirection.Descending)]
public void Test_SortByMax_String(BubbleShort<string>.SortDirection direction)
{
    var sorter = new BubbleShort<string>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomStringMatrix();
    sorter.Sort(matrix, sorter.MaxSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        string max1 = (string)sorter.MaxSelector(matrix[i]);
        string max2 = (string)sorter.MaxSelector(matrix[i + 1]);
        if (direction == BubbleShort<string>.SortDirection.Ascending)
            Assert.True(string.Compare(max1, max2) <= 0);
        else
            Assert.True(string.Compare(max1, max2) >= 0);
    }
}

[Xunit.Theory]
[InlineData(BubbleShort<string>.SortDirection.Ascending)]
[InlineData(BubbleShort<string>.SortDirection.Descending)]
public void Test_SortBySum_String(BubbleShort<string>.SortDirection direction)
{
    var sorter = new BubbleShort<string>();
    sorter.SetSortDirection(direction);

    var matrix = GenerateRandomStringMatrix();
    sorter.Sort(matrix, sorter.SumSelector);

    for (int i = 0; i < matrix.Length - 1; i++)
    {
        int sum1 = (int)sorter.SumSelector(matrix[i]);
        int sum2 = (int)sorter.SumSelector(matrix[i + 1]);
        if (direction == BubbleShort<string>.SortDirection.Ascending)
            Assert.True(sum1 <= sum2);
        else
            Assert.True(sum1 >= sum2);
    }
}

[Fact]
public void Test_SortByMin_String_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<string>();
    var original = GenerateRandomStringMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.MinSelector);

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Descending);
    sorter.Sort(desc, sorter.MinSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByFirstElement_String_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<string>();
    var original = GenerateRandomStringMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.FirstElementSelector);

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Descending);
    sorter.Sort(desc, sorter.FirstElementSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

[Fact]
public void Test_SortByLength_String_AscendingAndDescending_AreReverse()
{
    var sorter = new BubbleShort<string>();
    var original = GenerateRandomStringMatrix();

    var asc = original.Select(row => row.ToArray()).ToArray();
    var desc = original.Select(row => row.ToArray()).ToArray();

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Ascending);
    sorter.Sort(asc, sorter.LengthSelector);

    sorter.SetSortDirection(BubbleShort<string>.SortDirection.Descending);
    sorter.Sort(desc, sorter.LengthSelector);

    for (int i = 0; i < asc.Length; i++)
        Assert.Equal(asc[i], desc[desc.Length - 1 - i]);
}

}