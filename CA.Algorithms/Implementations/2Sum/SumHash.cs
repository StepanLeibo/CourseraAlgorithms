using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedMeasure;

namespace CA.Algorithms.Implementations._2Sum
{
    public class SumHash:I2SumAlgorithm
    {
        private static Dictionary<int, bool> _hashTable;
        public bool Match2Sum(int[] array, int t)
        {
            //var measureTableCreation = new Measure("Hash table creation");
            //measureTableCreation.StartMeasure();
            if (_hashTable == null)
            {
                _hashTable = new Dictionary<int, bool>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (!_hashTable.ContainsKey(array[i]))
                        _hashTable.Add(array[i], true);
                }
            }
            //measureTableCreation.StopMeasureDisplay();

            //var measureLookForMatch = new Measure("2 sum match");
            //measureLookForMatch.StartMeasure();
            for (int i = 0; i < array.Length; i++)
            {
                int y = t - array[i];
                if (_hashTable.ContainsKey(y) && array[i] != y)
                {
                    //measureLookForMatch.StopMeasureDisplay();
                    return true;
                }
            }
            //measureLookForMatch.StopMeasureDisplay();

            return false;
        }
    }
}
