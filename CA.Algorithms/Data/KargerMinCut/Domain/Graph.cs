using System;
using System.Collections.Generic;

namespace CA.Algorithms.Data.KargerMinCut.Domain
{
    public class Graph : ICloneable
    {
        public List<int> Vertices = new List<int>();

        public List<Edge> Edges = new List<Edge>();
        
        public object Clone()
        {
            return new Graph
                       {
                           Edges = new List<Edge>(Edges),
                           Vertices = new List<int>(Vertices)
                       };
        }
    }
}
