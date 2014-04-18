using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class GraphHelper
    {
        public static void SetVerticesUnfound(GraphScc graph)
        {
            foreach (var vertex in graph.Vertices)
            {
                vertex.Found = false;
            }
        }

        public static void SetVerticesUnfound(List<VertexEdgesScc> graph)
        {
            foreach (var vertex in graph)
            {
                vertex.Found = false;
                vertex.Index = -1;
                vertex.LowLink = -1;
            }
        }
    }
}
