using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedMeasure;

namespace CA.Algorithms.Implementations._2Sum
{
    public class SumNativeSolution : I2SumAlgorithm
    {
        public bool Match2Sum(int[] array, int t)
        {
            var measureLookForMatch = new Measure("2 sum match");
            measureLookForMatch.StartMeasure();
            for(int i = 0; i < array.Length; i ++)
            {    for (int j = 0; j < array.Length; j++)
                {
                    if (i < j)
                    {
                        if (array[i] + array[j] == t)
                        {
                            measureLookForMatch.StopMeasureDisplay();
                            return true;
                        }
                    }
                }
            }
            measureLookForMatch.StopMeasureDisplay();
            return false;
        }
    }
}
