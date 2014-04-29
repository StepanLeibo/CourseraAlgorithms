using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public interface IGetVerteciesScc
    {
        List<VertexWithEdgesScc> GetGraph();
    }
}
