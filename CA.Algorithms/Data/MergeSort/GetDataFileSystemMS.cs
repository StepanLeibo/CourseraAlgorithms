using System;
using System.Collections.Generic;
using System.IO;

namespace CA.Algorithms.Data.MergeSort
{
    public class GetDataFileSystemMS:IGetMergeSortData
    {
        public int[] GetDataArray()
        {
            var data = new List<int>();
            string[] allLines = File.ReadAllLines(@"..\..\..\CA.Algorithms\Data\MergeSort\IntegerArray.txt");
            foreach (var line in allLines)
            {
                data.Add(Convert.ToInt32(line));
            }

            return data.ToArray();
        }
    }
}
