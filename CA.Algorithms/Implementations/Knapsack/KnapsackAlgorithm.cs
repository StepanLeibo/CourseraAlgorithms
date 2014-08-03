using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.Knapsack;

namespace CA.Algorithms.Implementations.Knapsack
{
    public class KnapsackAlgorithm
    {
        public int SolutionValue(KnapsackData knapsackData)
        {
            var knapsackArray = new int[knapsackData.Items.Length, knapsackData.KnapsackSize];

            for (var itemCount = 0; itemCount < knapsackData.Items.Length; itemCount++)
            {
                for (var weight = 0; weight < knapsackData.KnapsackSize; weight++)
                {
                    knapsackArray[itemCount, weight] = CalculateKnapsackValue(knapsackArray, knapsackData.Items[itemCount], itemCount, weight);
                }
            }

            return knapsackArray[knapsackData.Items.Length - 1, knapsackData.KnapsackSize -1];
        }

        private int CalculateKnapsackValue(int[,] knapsackArray, KnapsackItem knapsackItem, int itemCount, int weight)
        {
            var value1 = GetKnapsackArrayValue(knapsackArray, itemCount - 1, weight) ?? 0;
            var knapsackArrayValue = GetKnapsackArrayValue(knapsackArray, itemCount - 1, weight - knapsackItem.Weight);
            var value2 = knapsackArrayValue.HasValue ? knapsackArrayValue.Value + knapsackItem.Value : 0;
            return Math.Max(value1, value2);
        }

        private int? GetKnapsackArrayValue(int[,] knapsackArray, int itemCount, int weight)
        {
            if (weight < 0 || itemCount < 0)
            {
                return null;
            }

            return knapsackArray[itemCount, weight];
        }
    }
}
