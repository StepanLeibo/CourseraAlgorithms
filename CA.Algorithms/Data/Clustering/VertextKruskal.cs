using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.UnionFind;

namespace CA.Algorithms.Data.Clustering
{
    public class VertextKruskal : IUnionFindId
    {
        public VertextKruskal(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int LeaderId { get; set; }
    }
}
