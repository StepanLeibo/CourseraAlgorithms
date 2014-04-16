using System;

namespace CA.Algorithms.Implementations.MergeSort
{
    public class MergeSort
    {
        public int[] MergeSortCount(int[] unSortedArray, ref Int64 inversions)
        {
            return SortArray(unSortedArray, ref inversions);
        }

        private int[] SortArray(int[] unSortedArray, ref Int64 inversions)
        {
            if (unSortedArray.Length > 1)
            {
                int halfArray;
                int arrayLength = unSortedArray.Length;
                if (arrayLength % 2 == 1)
                {
                    halfArray = arrayLength / 2 + 1;
                }
                else
                {
                    halfArray = arrayLength / 2;
                }
                var firstPart = new int[halfArray];
                var secondPart = new int[arrayLength - halfArray];
                Array.Copy(unSortedArray, firstPart, halfArray);
                Array.Copy(unSortedArray, halfArray, secondPart, 0, arrayLength - halfArray);

                firstPart = SortArray(firstPart, ref inversions);
                secondPart = SortArray(secondPart, ref inversions);

                int[] sortedArray = CombineArrays(firstPart, secondPart, ref inversions);

                return sortedArray;
            }
            else
            {
                return unSortedArray;
            }
        }

        private int[] CombineArrays(int[] firstPart, int[] secondPart, ref Int64 inversions)
        {
            int i = 0, 
                j = 0, 
                fpLength = firstPart.Length,
                spLength = secondPart.Length,
                totalLength = fpLength + spLength;
            var sortedArray = new int[totalLength];
            for (int c = 0; c < totalLength; c++)
            {
                if (i < fpLength)
                {
                    if (j == spLength || firstPart[i] <= secondPart[j] )
                    {
                        sortedArray[c] = firstPart[i];
                        i++;
                        //if (j == spLength && i < fpLength)
                        //    inversions++;
                        continue;
                    }
                    else
                    {
                        inversions+=fpLength+j -i - (c-i);
                    }
                }

                sortedArray[c] = secondPart[j];
                if(j < spLength)
                    j++;
            }

            return sortedArray;
        }
    }
}
