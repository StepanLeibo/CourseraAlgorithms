using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.UnionFind;

namespace CA.Algorithms.Data.Clustering
{
    public class ClusteringItem : IUnionFindId
    {
        public ClusteringItem(int id, int bits)
        {
            Id = id;
            ItemData = new bool[bits];
        }

        public int Id { get; set; }
        public int LeaderId { get; set; }

        public bool[] ItemData { get; set; }

        public Int32 IntData { get; set; }
    }
}
