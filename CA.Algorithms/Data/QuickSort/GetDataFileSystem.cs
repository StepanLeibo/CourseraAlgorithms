using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CA.Algorithms.Data.QuickSort
{
    public class GetDataFileSystem:IGetQuickSortData
    {
        public int[] GetDataArray()
        {
            string[] allLines = File.ReadAllLines(@"..\..\..\CA.Algorithms\Data\QuickSort\QuickSort.txt");

            return allLines.Select(line => Convert.ToInt32(line)).ToArray();
        }
    }
}
