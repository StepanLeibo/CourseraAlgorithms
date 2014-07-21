using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.Clustering;

namespace CA.Algorithms.Implementations.Clustering
{
    public class ClusteringItemsComparer : IClusteringItemComparer
    {
        public IEnumerable<ClusterItemsDistance> GetOrderedDistance(ClusteringItem[] items)
        {
            for (int targetDistance = 1; targetDistance < 3; targetDistance++)
            {
                //var measure1 = new SpeedMeasure.Measure("Second1000");
                //measure1.StartMeasure();
                int first = 0;
                int second = 1;
                while (first < items.Length)
                {
                   
                        //var distance = GetDistance(items[first].ItemData, items[second].ItemData, targetDistance);
                        var distance = GetDistance(items[first].IntData, items[second].IntData);
                        if (distance <= targetDistance)
                        {
                            yield return new ClusterItemsDistance(first, second, distance);
                        }


                        //if (first != 0 && first % 1000 == 0 && second == first+1)
                        //{
                        //    Console.WriteLine(first);
                        //    measure1.StopMeasureDisplay();
                        //}

                    second++;
                    if (second == items.Length)
                    {
                        first++;
                        second = first + 1;
                    }
                }
            }
        }

        private int GetDistance(bool[] data1, bool[] data2)
        {
            var distance = 0;

            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                {
                    distance++;
                }
            }

            return distance;
        }

        private int GetDistance(bool[] data1, bool[] data2, int targetDistance)
        {
            var distance = 0;

            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                {
                    distance++;
                    if (distance > targetDistance)
                        return int.MaxValue;
                }
            }

            return distance;
        }

        private int GetDistance(Int32 data1, Int32 data2)
        {
            var i = data1 ^ data2;

            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }
    }
}
