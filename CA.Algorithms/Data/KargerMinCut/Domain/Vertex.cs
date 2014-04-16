using System;
using System.Collections.Generic;

namespace CA.Algorithms.Data.KargerMinCut.Domain
{
    public class Vertex : ICloneable
    {
        public int ID { get; set; }
        public List<Edge> Edges { get; set; }
        public List<int> SubVertexes { get; set; }

        public Vertex()
        {
            Edges = new List<Edge>();
            SubVertexes = new List<int>();
        }

        public object Clone()
        {
            return new Vertex
                       {
                           ID = ID,
                           Edges = new List<Edge>(Edges),
                           SubVertexes = new List<int>(SubVertexes)
                       };
        }
    }
}
