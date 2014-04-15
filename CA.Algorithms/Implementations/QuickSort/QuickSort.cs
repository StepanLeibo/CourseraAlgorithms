namespace CA.Algorithms.Implementations.QuickSort
{
    public class QuickSort
    {
        private IPivot _pivot;

        public QuickSort(IPivot pivotHelper)
        {
            _pivot = pivotHelper;
        }

        public void QuickSortAlgorithm(int[] a, int first, int last, ref long exchCount)
        {
            if(last - first < 1 )
                return;
            exchCount += last - first;
            var pivotIndex = 0;
            var pivot = _pivot.GetPivot(a, first, last, ref pivotIndex);
            int i = first;
            ChangeIJ(a, first, pivotIndex);
            pivotIndex = first;
            for (var j = first; j <= last; j++ )
            {
                if (i == pivotIndex)
                    i++;
                if (j == pivotIndex)
                    continue;

                if (a[j] < pivot)
                {
                    ChangeIJ(a, i, j);
                    i++;
                }
            }
            
            if (i > pivotIndex)
            {
                i--;
                ChangeIJ(a, pivotIndex, i);
            }
            else
            {
                ChangeIJ(a, pivotIndex, i);
            }

            QuickSortAlgorithm(a, first, i-1, ref exchCount);
            QuickSortAlgorithm(a, i+1, last, ref exchCount);
        }

        private void ChangeIJ(int[] a, int i, int j)
        {
            int temp = a[j];
            a[j] = a[i];
            a[i] = temp;
        }
    }
}
