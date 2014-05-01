using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.GraphObjects
{
    public class VertexBase
    {
        public int Id { get; set; }
    }

    public class VertexWithEdges : VertexBase
    {
        public List<int> Edges { get; set; }

        public VertexWithEdges()
        {
            Edges = new List<int>();
        }
    }
}
