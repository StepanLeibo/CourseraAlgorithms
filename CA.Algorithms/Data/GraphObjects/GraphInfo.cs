using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.GraphObjects
{
    public class GraphBase
    {
        public List<VertexBase> Vertices { get; set; }
        public List<EdgeBase> Edges { get; set; }
    }
}
