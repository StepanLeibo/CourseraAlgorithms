using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.Clustering
{
    public class ClusterItemsDistance
    {
        public ClusterItemsDistance(int start, int end, int distance)
        {
            Start = start;
            End = end;
            Distance = distance;
        }

        public int Start { get; set; }
        public int End { get; set; }
        public int Distance { get; set; }
    }
}
