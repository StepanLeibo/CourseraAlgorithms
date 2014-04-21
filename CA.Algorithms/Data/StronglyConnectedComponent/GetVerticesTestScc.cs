using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public class GetVerticesTestScc : IGetVerteciesScc
    {
        public List<VertexEdgesScc> GetGraph()
        {
            var graph = new List<VertexEdgesScc>
                            {
                                new VertexEdgesScc(0),
                                new VertexEdgesScc
                                    {
                                        ID = 1,
                                        Edges = {7}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 2,
                                        Edges = {5}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 3,
                                        Edges = {9}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 4,
                                        Edges = {1}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 5,
                                        Edges = {8}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 6,
                                        Edges = {3, 8}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 7,
                                        Edges = {4, 9}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 8,
                                        Edges = {2}
                                    },
                                new VertexEdgesScc
                                    {
                                        ID = 9,
                                        Edges = {6}
                                    },
                            };
            return graph;
        }
    }
}
