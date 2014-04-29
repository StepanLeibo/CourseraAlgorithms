using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class SccGraphHelper
    {
        public static void SetVerticesUnfound(List<VertexWithEdgesScc> graph)
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
