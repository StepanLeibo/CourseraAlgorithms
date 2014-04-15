namespace CA.Algorithms.Implementations.QuickSort
{
    public class PivotLastElement:IPivot
    {
        public int GetPivot(int[] a, int first, int last, ref int pivotIndex)
        {
            pivotIndex = last;
            return a[last];
        }
    }
}
