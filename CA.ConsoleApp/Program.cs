using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using CA.Algorithms.Data.KargerMinCut;
using CA.Algorithms.Data.KargerMinCut.Domain;
using CA.Algorithms.Data.MedianMaintenance;
using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Data.SccKosaraju;
using CA.Algorithms.Data.ShortestPathDijkstra;
using CA.Algorithms.Data._2Sum;
using CA.Algorithms.Implementations.KargerMinKut;
using CA.Algorithms.Implementations.MedianMaintenance;
using CA.Algorithms.Implementations.MergeSort;
using CA.Algorithms.Implementations.QuickSort;
using CA.Algorithms.Implementations.SccKosaraju;
using CA.Algorithms.Implementations.ShortestPathDijkstra;
using CA.Algorithms.Implementations._2Sum;
using CA.DI;
using Ninject;
using Ninject.Parameters;
using SpeedMeasure;

namespace CA.ConsoleApp
{
    class Program
    {
        static readonly IKernel Ninj = new DependencyInjection().NinjectKernel;
        static void Main()
        {
            //QuickSort();
            //MergeSort();
            //KargerMinCut();
            //DijkstraShortestPath();
            //StronglyConnectedComponent();
            //SumAlgorithm();
            MedianMaintenance();
        }

        public static void QuickSort()
        {
            var dataManager = Ninj.Get<IGetQuickSortData>();
            var pivot = Ninj.Get<IPivot>();
            var quickSort = Ninj.Get<QuickSort>();

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
            var mergeSort = Ninj.Get<MergeSort>();
            var dataManager = Ninj.Get<IGetMergeSortData>();
            Int64 inversions = 0;

            mergeSort.MergeSortCount(dataManager.GetDataArray(), ref inversions);

            Console.WriteLine("Inversions count: {0}", inversions);
        }

        private static void KargerMinCut()
        {
            var kargerData = Ninj.Get<IGetGraphKarger>();
            var kargerMinCut = Ninj.Get<IKargerMinCut>();

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

        private static void PrintGraph(GraphKmc graph)
        {
            foreach (var vertex in graph.Vertices)
            {
                Console.Write("{0} ", vertex);
                foreach (var edge in graph.Edges)
                {
                    if (edge.StartPoint == vertex)
                        Console.Write("{0} ", edge.EndPoint);
                }

                Console.WriteLine();
            }
        }

        private static void DijkstraShortestPath()
        {
            var dataManager = Ninj.Get<IGetListVertexes>();
            var dijkstraShortPath = Ninj.Get<Dijkstra>();

            var path = dijkstraShortPath.Agorithm(dataManager.GetVerteces(), 1);
            var verArray = new[] {7, 37, 59, 82, 99, 115, 133, 165, 188, 197};
            
            for (var i = 0; i < path.Length; i++)
            {
                if(verArray.Contains(i))
                    Console.WriteLine("{0}:{1}", i, path[i]);
            }
        }

        private static void StronglyConnectedComponent()
        {
            var dataManager = Ninj.Get<IGetGraphScc>();
            var sccAlgorithm = Ninj.Get<SccAlgorithm>();
            const int stackSize = 1000000000;

            var thread = new Thread(() => sccAlgorithm.FindComponents(dataManager.GetGraph()), stackSize);

            thread.Start();
        }

        private static void SumAlgorithm()
        {
            var dataManager = Ninj.Get<IGet2SumData>();
            var sumAlgorithm = Ninj.Get<I2SumAlgorithm>();
            var measure = new Measure("2-Sum");

            int counter = 0;
            measure.StartMeasure();
            for (int t = 2500; t <= 4000; t++)
            {
                if (sumAlgorithm.Match2Sum(dataManager.GetData(), t))
                {
                    counter++;
                }
            }
            measure.StopMeasureDisplay();

            Console.WriteLine(counter);
        }

        private static void MedianMaintenance()
        {
            var dataManager = Ninj.Get<IGetMedianMaintenanceData>();
            var medianMaintenanceAlgorithm = Ninj.Get<MedianMaintenanceAlgorith>();

            var medianSum = 0;
            foreach (var item in dataManager.GetData())
            {
                medianSum += medianMaintenanceAlgorithm.GetMedianWithNewItem(item);
            }

            Console.WriteLine(medianSum % 10000);
        }
    }
}
