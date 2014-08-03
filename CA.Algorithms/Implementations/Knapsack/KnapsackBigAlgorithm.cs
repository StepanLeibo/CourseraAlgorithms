using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.Knapsack;

namespace CA.Algorithms.Implementations.Knapsack
{
    public class KnapsackBigAlgorithm
    {
        public void SolutionValue(KnapsackData knapsackData)
        {
            var knapsackArray = new int[knapsackData.KnapsackSize];
            var knapsackMemo = new int[knapsackData.KnapsackSize];

            var measure = new SpeedMeasure.Measure("Knapsack");

            measure.StartMeasure();
            var measureCounter = 0;
            foreach (var knapsackItem in knapsackData.Items)
            {
                for (var weight = knapsackItem.Weight; weight < knapsackData.KnapsackSize; weight++)
                {
                    knapsackArray[weight] = knapsackMemo[weight];
                    var weightIndex = weight - knapsackItem.Weight;
                    
                    var knapsackValue = knapsackMemo[weightIndex] + knapsackItem.Value;
                    knapsackArray[weight] = knapsackMemo[weight] > knapsackValue
                                ? knapsackMemo[weight]
                                : knapsackValue;
                    
                }

                measureCounter++;
                if (measureCounter % 10 == 0)
                {
                    measure.StopMeasureDisplay();
                }

                Array.Copy(knapsackArray, knapsackMemo, knapsackArray.Length);
            }

            Console.WriteLine(knapsackArray[knapsackData.KnapsackSize - 1]);
        }

        private int CalculateKnapsackValue(int[] knapsackMemo, KnapsackItem knapsackItem, int weight)
        {
            //var value1 = GetKnapsackMemoValue(knapsackMemo, weight) ?? 0;
            //var knapsackArrayValue = GetKnapsackMemoValue(knapsackMemo, weight - knapsackItem.Weight);
            //var value2 = knapsackArrayValue.HasValue ? knapsackArrayValue.Value + knapsackItem.Value : 0;
            //return Math.Max(value1, value2);

            if (weight >= 0)
            {
                var calculateKnapsackValue = knapsackMemo[weight];
                if (weight - knapsackItem.Weight >= 0)
                {
                    var knapsackValue = knapsackMemo[weight - knapsackItem.Weight] + knapsackItem.Value;
                    return calculateKnapsackValue > knapsackValue
                               ? calculateKnapsackValue
                               : knapsackValue;
                }

                return calculateKnapsackValue;
            }

            return 0;

            //var value1 =  weight >= 0 ? knapsackMemo[weight] : 0;
            //var value2 = weight - knapsackItem.Weight >= 0 
            //    ? knapsackMemo[weight - knapsackItem.Weight] + knapsackItem.Value 
            //    : 0;
            //return value1 > value2 ? value1 : value2;
        }

        private int? GetKnapsackMemoValue(int[] knapsackMemo, int weight)
        {
            if (weight < 0 )
            {
                return null;
            }

            return knapsackMemo[weight];
        }
    }
}
