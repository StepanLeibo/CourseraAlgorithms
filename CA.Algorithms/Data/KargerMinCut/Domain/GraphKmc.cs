using System;
using System.Collections.Generic;

namespace CA.Algorithms.Data.KargerMinCut.Domain
{
    public class GraphKmc : ICloneable
    {
        public List<int> Vertices = new List<int>();

        public List<EdgeKmc> Edges = new List<EdgeKmc>();
        
        public object Clone()
        {
            return new GraphKmc
                       {
                           Edges = new List<EdgeKmc>(Edges),
                           Vertices = new List<int>(Vertices)
                       };
        }
    }
}
