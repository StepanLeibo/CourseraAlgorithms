using System.Collections.Generic;

namespace CA.Algorithms.Data.ShortestPathDijkstra.Domain
{
    public class VertexSp
    {
        public int ID { get; set; }
        public List<EdgeSp> Edges { get; set; }

        public VertexSp()
        {
            Edges = new List<EdgeSp>();
        }
    }
}
