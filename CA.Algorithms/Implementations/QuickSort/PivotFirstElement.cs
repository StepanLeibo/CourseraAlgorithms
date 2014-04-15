namespace CA.Algorithms.Implementations.QuickSort
{
    public class PivotFirstElement : IPivot
    {
        public int GetPivot(int[] a, int first, int last, ref int pivotIndex)
        {
            pivotIndex = first;
            return a[first];
        }
    }
}
