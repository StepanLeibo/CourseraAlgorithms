using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.PrimMst
{
    public class EdgePrim : IComparable<EdgePrim>
    {
        public EdgePrim(int end, int cost)
        {
            End = end;
            Cost = cost;
        }

        public int End { get; set; }

        public int Cost { get; set; }
        public int CompareTo(EdgePrim edge)
        {
            return Cost - edge.Cost;
        }
    }
}
