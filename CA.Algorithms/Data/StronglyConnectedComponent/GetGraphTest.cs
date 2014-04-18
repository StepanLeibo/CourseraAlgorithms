using System.Collections.Generic;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public class GetGraphTestScc : IGetGraphScc
    {
        public GraphScc GetGraph()
        {
            var graph = new GraphScc
                {
                    Vertices = {1, 2, 3, 4, 5, 6, 7,8,9},
                    Edges = new List<EdgeScc>
                        {
                            new EdgeScc
                                {
                                    StartPoint = 1,
                                    EndPoint = 7
                                },
                            new EdgeScc
                                {
                                    StartPoint = 7,
                                    EndPoint = 4
                                },
                            new EdgeScc
                                {
                                    StartPoint = 7,
                                    EndPoint = 9
                                },
                            new EdgeScc
                                {
                                    StartPoint = 4,
                                    EndPoint = 1
                                },
                            new EdgeScc
                                {
                                    StartPoint = 9,
                                    EndPoint = 6
                                },
                            new EdgeScc
                                {
                                    StartPoint = 6,
                                    EndPoint = 3
                                },
                            new EdgeScc
                                {
                                    StartPoint = 6,
                                    EndPoint = 8
                                },
                            new EdgeScc
                                {
                                    StartPoint = 3,
                                    EndPoint = 9
                                },
                            new EdgeScc
                                {
                                    StartPoint = 8,
                                    EndPoint = 2
                                },
                            new EdgeScc
                                {
                                    StartPoint = 2,
                                    EndPoint = 5
                                },
                            new EdgeScc
                                {
                                    StartPoint = 5,
                                    EndPoint = 8
                                }
                        }
                };
            return graph;
        }
    }
}
