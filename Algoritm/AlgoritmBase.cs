namespace Algoritm;

public class AlgoritmBase<T> 
{
    public delegate IComparable KeySelector<T>(T[] row);
    public List<List<int>> Matrix { get; set; } = new List<List<int>>();

    public void Swop<V>(ref V positionA, ref V positionB) => (positionA, positionB) = (positionB, positionA);

    public virtual void Sort(T[][] matrix,KeySelector<T> keySelector)
    {
        Matrix.Sort();
    }
}