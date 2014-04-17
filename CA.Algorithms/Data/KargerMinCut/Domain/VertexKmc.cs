using System;
using System.Collections.Generic;

namespace CA.Algorithms.Data.KargerMinCut.Domain
{
    public class VertexKmc : ICloneable
    {
        public int ID { get; set; }
        public List<EdgeKmc> Edges { get; set; }
        public List<int> SubVertexes { get; set; }

        public VertexKmc()
        {
            Edges = new List<EdgeKmc>();
            SubVertexes = new List<int>();
        }

        public object Clone()
        {
            return new VertexKmc
                       {
                           ID = ID,
                           Edges = new List<EdgeKmc>(Edges),
                           SubVertexes = new List<int>(SubVertexes)
                       };
        }
    }
}
