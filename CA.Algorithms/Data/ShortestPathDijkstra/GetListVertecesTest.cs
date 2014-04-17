using System.Collections.Generic;
using CA.Algorithms.Data.ShortestPathDijkstra.Domain;

namespace CA.Algorithms.Data.ShortestPathDijkstra
{
    public class GetListVertecesTest : IGetListVertexes
    {
        public List<VertexSp> GetVerteces()
        {
            return new List<VertexSp>
                {
                    new VertexSp
                        {
                            ID = 0
                        },
                    new VertexSp
                        {
                            ID = 1,
                            Edges = new List<EdgeSp>
                                {
                                    new EdgeSp
                                        {
                                            StartPoint = 1,
                                            EndPoint = 2,
                                            Weight = 1
                                        },
                                    new EdgeSp
                                        {
                                            StartPoint = 1,
                                            EndPoint = 4,
                                            Weight = 5
                                        }
                                }
                        },
                    new VertexSp
                        {
                            ID = 2,
                            Edges = new List<EdgeSp>
                                {
                                    new EdgeSp
                                        {
                                            StartPoint = 2,
                                            EndPoint = 4,
                                            Weight = 2
                                        },
                                    new EdgeSp
                                        {
                                            StartPoint = 2,
                                            EndPoint = 3,
                                            Weight = 4
                                        }
                                }
                        },
                    new VertexSp
                        {
                            ID = 3
                        },
                    new VertexSp
                        {
                            ID = 4,
                            Edges = new List<EdgeSp>
                                {
                                    new EdgeSp
                                        {
                                            StartPoint = 4,
                                            EndPoint = 3,
                                            Weight = 1
                                        }
                                }
                        }
                };
        }
    }
}
