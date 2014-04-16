using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CA.Algorithms.Data.KargerMinCut;
using CA.Algorithms.Data.KargerMinCut.Domain;
using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Implementations.KargerMinKut;
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
            //MergeSort();
            KargerMinCut();
        }
        
        public static void QuickSort()
        {
            var dataManager = ninj.NinjectKernel.Get<IGetQuickSortData>();
            var pivot = ninj.NinjectKernel.Get<IPivot>();
            var quickSort = ninj.NinjectKernel.Get<QuickSort>();

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
            var mergeSort = ninj.NinjectKernel.Get<MergeSort>();
            var dataManager = ninj.NinjectKernel.Get<IGetMergeSortData>();
            Int64 inversions = 0;

            mergeSort.MergeSortCount(dataManager.GetDataArray(), ref inversions);

            Console.WriteLine("Inversions count: {0}", inversions);
        }

        private static void KargerMinCut()
        {
            var kargerData = ninj.NinjectKernel.Get<IGetGraphKarger>();
            var kargerMinCut = ninj.NinjectKernel.Get<IKargerMinCut>();

            //PrintGraph(kargerData.GetGraph());

            int min = 1000;

            for (int c = 0; c < 10000; c++)
            {
                int test = kargerMinCut.MinCut(kargerData.GetGraph());
                if (min > test)
                {
                    min = test;
                }

                //Console.Write("{0} ", test);
            }

            Console.WriteLine(min);
        }

        private static void PrintGraph(Graph graph)
        {
            foreach (var vertex in graph.Vertices)
            {
                System.Console.Write(string.Format("{0} ", vertex));
                foreach (var edge in graph.Edges)
                {
                    if (edge.StartPoint == vertex)
                        System.Console.Write(string.Format("{0} ", edge.EndPoint));
                }

                System.Console.WriteLine();
            }
        }
    }
}
