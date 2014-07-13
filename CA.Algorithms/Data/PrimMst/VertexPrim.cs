using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Implementations.BinaryTree;

namespace CA.Algorithms.Data.PrimMst
{
    public class VertexPrim : IComparable<VertexPrim>
    {
        public VertexPrim(int id)
        {
            Edges = new List<EdgePrim>();
            CrossEdges = new Heap<EdgePrim>(true);
            Id = id;
        }

        public int Id { get; set; }

        public List<EdgePrim> Edges { get; set; }

        public Heap<EdgePrim> CrossEdges { get; set; }

        public int VertexCost
        {
            get { return CrossEdges.Count != 0 ? CrossEdges.Peek().Cost : int.MaxValue; }
            private set { }
        }
        
        public int CompareTo(VertexPrim otherVertex)
        {
            return VertexCost - otherVertex.VertexCost;
        }
    }
}
