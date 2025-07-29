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
            for (int j = 0; j < matrix[i].Length - i - 1; j++)
            {
                int cmp = keySelector(matrix[j]).CompareTo(keySelector(matrix[j + 1]));
                bool needSwap = _sortDirection == SortDirection.Ascending ? cmp > 0 : cmp < 0;
                if (needSwap) Swop(ref matrix[j], ref matrix[j + 1]);
            }
        }
    }


    // ---------- Статические критерии сортировки ----------

    public IComparable SumSelector<T>(T[] row)
    {
        dynamic sum = default(T);
        foreach (var item in row)
            sum += (dynamic)item;
        return sum;
    }

    public  IComparable MaxSelector<T>(T[] row)
    {
        dynamic max = row[0];
        foreach (var item in row)
            if ((dynamic)item > max)
                max = item;
        return max;
    }

    public  IComparable MinSelector<T>(T[] row)
    {
        dynamic min = row[0];
        foreach (var item in row)
            if ((dynamic)item < min)
                min = item;
        return min;
    }

    public IComparable LengthSelector<T>(T[] row) {
        return row.Length;
    }

    // public IComparable FirstElementSelector<T>(T[] row) 
    // {
    //     return row[0];
    // }
}