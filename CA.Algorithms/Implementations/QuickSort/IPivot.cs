namespace CA.Algorithms.Implementations.QuickSort
{
    public interface IPivot
    {
        int GetPivot(int[] a, int first, int last, ref int pivotIndex);
    }
}
