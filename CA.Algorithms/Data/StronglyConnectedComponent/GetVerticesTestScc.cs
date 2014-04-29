using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public class GetVerticesTestScc : IGetVerteciesScc
    {
        public List<VertexWithEdgesScc> GetGraph()
        {
            var graph = new List<VertexWithEdgesScc>
                            {
                                new VertexWithEdgesScc(0),
                                new VertexWithEdgesScc
                                    {
                                        ID = 1,
                                        Edges = {7}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 2,
                                        Edges = {5}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 3,
                                        Edges = {9}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 4,
                                        Edges = {1}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 5,
                                        Edges = {8}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 6,
                                        Edges = {3, 8}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 7,
                                        Edges = {4, 9}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 8,
                                        Edges = {2, 3}
                                    },
                                new VertexWithEdgesScc
                                    {
                                        ID = 9,
                                        Edges = {6}
                                    },
                            };
            return graph;
        }
    }
}
