using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CA.Algorithms.Data.Clustering;

namespace CA.Algorithms.Implementations.Clustering
{
    public class ClusteringItemsComparerDictionary : IClusteringItemComparer
    {
        private Dictionary<int, List<int>> itemsDictionary;
        
        public ClusteringItemsComparerDictionary()
        {
            itemsDictionary = new Dictionary<int, List<int>>();
        }

        public IEnumerable<ClusterItemsDistance> GetOrderedDistance(ClusteringItem[] items)
        {
            var bits = items[0].ItemData.Length;

            for (int i = 0; i < items.Length; i++)
            {
                if (!itemsDictionary.ContainsKey(items[i].IntData))
                {
                    itemsDictionary.Add(items[i].IntData, new List<int> { items[i].Id });
                }
                else
                {
                    itemsDictionary[items[i].IntData].Add(items[i].Id);
                }
            }

            for (int i = 0; i < items.Length; i++)
            {
                var intData = items[i].IntData;

                if (itemsDictionary[intData].Count > 1)
                {
                    foreach (var id in itemsDictionary[intData])
                    {
                        if (id != i)
                        {
                            yield return new ClusterItemsDistance(i, id, 0);
                        }
                    }
                }
            }

            for (int i = 0; i < items.Length; i++)
            {
                var intData = items[i].IntData;

                for (int j = 0; j < bits; j++)
                {
                    var inversedIntData = InverseBit(intData, j);
                    if (itemsDictionary.ContainsKey(inversedIntData))
                    {
                        foreach (var id in itemsDictionary[inversedIntData])
                        {
                            yield return new ClusterItemsDistance(i, id, 1);
                        }
                    }
                }
            }

            for (int i = 0; i < items.Length; i++)
            {
                var intData = items[i].IntData;

                for (int j = 0; j < bits; j++)
                {
                    var inversedIntData = InverseBit(intData, j);
                    for (int k = 0; k < bits; k++)
                    {
                        if (k != j)
                        {
                            var inversedTwiceData = InverseBit(inversedIntData, k);
                            if (itemsDictionary.ContainsKey(inversedTwiceData))
                            {
                                foreach (var id in itemsDictionary[inversedTwiceData])
                                {
                                    yield return new ClusterItemsDistance(i, id, 1);
                                }
                            }
                        }
                    }
                }
            }
        }

        private int InverseBit(int intData, int bitNumber)
        {
            return intData ^ (1 << bitNumber);
        }
    }
}
