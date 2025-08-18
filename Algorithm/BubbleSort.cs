// <copyright file="BubbleSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Globalization;

namespace Algorithm;

internal sealed class BubbleSort<T> : AlgorithmBase<T[]>
{
    public override void Sort(IList<T[]> collection, Comparer<T[]> comparer)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(comparer);

        var n = collection.Count;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (comparer(collection[j], collection[j + 1]) > 0)
                {
                    (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                }
            }
        }
    }

    private static double ToDouble(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return obj switch
        {
            string s => s.Length,
            IConvertible _ => Convert.ToDouble(obj, CultureInfo.InvariantCulture),
            _ => throw new InvalidOperationException($"Невозможно преобразовать объект типа {obj.GetType()} в double"),
        };
    }

    private static double Sum(T[] array)
    {
        double sum = 0;
        foreach (var item in array)
        {
            ArgumentNullException.ThrowIfNull(item);
            sum += ToDouble(item);
        }

        return sum;
    }

    private static double Max(T[] array)
    {
        if (array.Length == 0)
        {
            return double.MinValue;
        }

        var first = array[0];
        ArgumentNullException.ThrowIfNull(first);
        var max = ToDouble(first);
        for (var i = 1; i < array.Length; i++)
        {
            var item = array[i];
            ArgumentNullException.ThrowIfNull(item);
            var val = ToDouble(item);
            if (val > max)
            {
                max = val;
            }
        }

        return max;
    }

    private static double Min(T[] array)
    {
        if (array.Length == 0)
        {
            return double.MaxValue;
        }

        var min = ToDouble(array[0] ?? throw new InvalidOperationException());
        for (var i = 1; i < array.Length; i++)
        {
            var val = ToDouble(array[i] ?? throw new InvalidOperationException());
            if (val < min)
            {
                min = val;
            }
        }

        return min;
    }

    public static Comparer<T[]> BySum() => (first, second) => Sum(first).CompareTo(Sum(second));

    public static Comparer<T[]> ByMax() => (first, second) => Max(first).CompareTo(Max(second));

    public static Comparer<T[]> ByMin() => (first, second) => Min(first).CompareTo(Min(second));

    public static Comparer<T[]> ByLength() => (first, second) => first.Length.CompareTo(second.Length);

    public static Comparer<T[]> ByFirstElement() => (first, second) => ToDouble(first[0] ?? throw new InvalidOperationException()).CompareTo(ToDouble(second[0] ?? throw new InvalidOperationException()));
}
