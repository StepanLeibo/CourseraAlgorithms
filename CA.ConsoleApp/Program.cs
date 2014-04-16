using System;
using System.Text.RegularExpressions;
using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Implementations.MergeSort;
using CA.Algorithms.Implementations.QuickSort;
using CA.DI;
using Ninject;
using Ninject.Parameters;

namespace CA.ConsoleApp
{
    class Program
    {
        static readonly DependencyInjection ninj = new DependencyInjection();
        static void Main()
        {
            //QuickSort();
            MergeSort();
        }

        public static void QuickSort()
        {
            var dataManager = ninj.NinjecKernel.Get<IGetQuickSortData>();
            var pivot = ninj.NinjecKernel.Get<IPivot>();
            var quickSort = ninj.NinjecKernel.Get<QuickSort>();

            var data = dataManager.GetDataArray();
            long exchCount = 0;

            quickSort.QuickSortAlgorithm(data, 0, data.Length - 1, ref exchCount);

            QuickSortPrintData(data, exchCount);
        }

        private static void QuickSortPrintData(int[] data, long exchCount)
        {
            foreach (var i in data)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
            Console.WriteLine("Exchange counter: {0}", exchCount);
        }

        private static void MergeSort()
        {
            var mergeSort = ninj.NinjecKernel.Get<MergeSort>();
            var dataManager = ninj.NinjecKernel.Get<IGetMergeSortData>();
            Int64 inversions = 0;

            mergeSort.MergeSortCount(dataManager.GetDataArray(), ref inversions);

            Console.WriteLine("Inversions count: {0}", inversions);
        }
    }
}
