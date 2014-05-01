using System.Collections.Generic;
using CA.Algorithms.Data.GraphObjects;

namespace CA.Algorithms.Data.SccKosaraju
{
    public class GetGraphSccTest : IGetGraphScc
    {
        public List<VertexWithEdges> GetGraph()
        {
            return new List<VertexWithEdges>
                {
                    new VertexWithEdges
                        {
                            Id = 0,
                            Edges = new List<int> {1}
                        },
                    new VertexWithEdges
                        {
                            Id = 1,
                            Edges = new List<int> {4, 5}
                        },
                    new VertexWithEdges
                        {
                            Id = 2,
                            Edges = new List<int> {6}
                        },
                    new VertexWithEdges
                        {
                            Id = 3,
                            Edges = new List<int> {1, 2}
                        },
                    new VertexWithEdges
                        {
                            Id = 4,
                            Edges = new List<int> {1, 3}
                        },
                    new VertexWithEdges
                        {
                            Id = 5,
                            Edges = new List<int> {4}
                        },
                    new VertexWithEdges
                        {
                            Id = 6,
                            Edges = new List<int> {7}
                        },
                    new VertexWithEdges
                        {
                            Id = 7,
                            Edges = new List<int> {2, 8}
                        },
                    new VertexWithEdges
                        {
                            Id = 8,
                            Edges = new List<int>() {}
                        }
                };
        }
    }
}
