using System.Collections.Generic;
using CA.Algorithms.Data.GraphObjects;

namespace CA.Algorithms.Data.SccKosaraju
{
    public interface IGetGraphScc
    {
        List<VertexWithEdges> GetGraph();
    }
}
