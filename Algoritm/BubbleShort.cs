namespace Algoritm;

public class BubbleShort<T> : AlgoritmBase<T> 
{
    public enum SortDirection { Ascending, Descending }
    
    private SortDirection _sortDirection = SortDirection.Ascending;
    
    // Метод для установки направления сортировки
    public void SetSortDirection(SortDirection direction)
    {
        _sortDirection = direction;
    }

    // public override void Sort(T[][] matrix, Func<T[], IComparable> keySelector)
    // {
    //     for (int i = 0; i < matrix.Length; i++)
    //     {
    //         for (int j = 0; j < matrix[i].Length - i - 1; j++)
    //         {
    //             IComparable key1 = keySelector(matrix[j]);
    //             IComparable key2 = keySelector(matrix[j + 1]);
    //
    //             int cmp = key1.CompareTo(key2);
    //             bool needSwap = _sortDirection == SortDirection.Ascending ? cmp > 0 : cmp < 0;
    //
    //             if (needSwap)
    //                 Swop(ref matrix[j], ref matrix[j + 1]);
    //         }
    //     }
    // }

    public override void Sort(T[][] matrix, KeySelector<T> keySelector)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix.Length - i - 1; j++)
            {
                int cmp = keySelector(matrix[j]).CompareTo(keySelector(matrix[j + 1]));
                bool needSwap = _sortDirection == SortDirection.Ascending ? cmp > 0 : cmp < 0;
                if (needSwap) Swop(ref matrix[j], ref matrix[j + 1]);
            }
        }
    }


    // ---------- Статические критерии сортировки ----------

    public IComparable SumSelector(T[] row)
    {
        if (row == null || row.Length == 0)
            throw new ArgumentException("Массив пуст или равен null");

        if (typeof(T) == typeof(string))
        {
            int sum = 0;
            foreach (var item in row)
                sum += ((string)(object)item).Length; // сумма длины строк
            return sum;
        }

        dynamic total = default(T);
        foreach (var item in row)
            total += (dynamic)item;
        return total;
    }

    public  IComparable MaxSelector(T[] row)
    {
        if (row == null || row.Length == 0)
            throw new ArgumentException("Массив пуст или равен null");

        IComparable max = row[0] as IComparable ?? throw new InvalidOperationException("Элемент не реализует IComparable");

        foreach (var item in row)
        {
            var comparable = item as IComparable;
            if (comparable == null)
                throw new InvalidOperationException("Элемент не реализует IComparable");

            if (comparable.CompareTo(max) > 0)
                max = comparable;
        }

        return max;
    }

    public  IComparable MinSelector(T[] row)
    {
        if (row == null || row.Length == 0)
            throw new ArgumentException("Массив пуст или равен null");

        IComparable min = row[0] as IComparable ?? throw new InvalidOperationException("Элемент не реализует IComparable");

        foreach (var item in row)
        {
            var comparable = item as IComparable;
            if (comparable == null)
                throw new InvalidOperationException("Элемент не реализует IComparable");

            if (comparable.CompareTo(min) < 0)
                min = comparable;
        }

        return min;
    }

    public IComparable LengthSelector(T[] row) {
        if (row == null || row.Length == 0)
            throw new ArgumentException("Массив пуст или равен null");
        return row.Length;
    }

    public IComparable FirstElementSelector(T[] row) 
    {
        if (row == null || row.Length == 0)
            throw new ArgumentException("Массив пуст или равен null");

        if (row[0] is IComparable comp)
            return comp;

        throw new InvalidOperationException($"Тип {typeof(T)} не реализует IComparable");
    }
}