using System;
using System.Collections.Generic;

namespace CA.Algorithms.Data.StronglyConnectedComponent.Domain
{
    public class GraphScc : ICloneable
    {
        public List<VertexScc> Vertices = new List<VertexScc>();

        public List<EdgeScc> Edges = new List<EdgeScc>();

        public object Clone()
        {
            return new GraphScc
            {
                Edges = new List<EdgeScc>(Edges),
                Vertices = new List<VertexScc>(Vertices)
            };
        }
    }
}
