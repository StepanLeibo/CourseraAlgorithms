using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.Knapsack
{
    public class KnapsackItem
    {
        public KnapsackItem(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }
        public int Weight { get; set; }
        public int Value { get; set; }
    }
}
