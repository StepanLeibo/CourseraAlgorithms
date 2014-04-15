using System;

namespace CA.Algorithms.Implementations.QuickSort
{
    public class PivotMedianElement : IPivot
    {
        public int GetPivot(int[] a, int first, int last, ref int pivotIndex)
        {
            pivotIndex = Math.Abs(first + (last - first)/2);
            if((a[pivotIndex] > a[first] && a[first] > a[last]) || (a[pivotIndex] < a[first] && a[first] < a[last]))
            {
                pivotIndex = first;
            } else if ((a[pivotIndex] > a[last] && a[last] > a[first]) || (a[pivotIndex] < a[last] && a[last] < a[first]))
            {
                pivotIndex = last;
            }

            return a[pivotIndex];
        }
    }
}
