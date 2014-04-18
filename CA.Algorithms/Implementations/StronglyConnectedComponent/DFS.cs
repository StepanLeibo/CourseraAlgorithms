using System;
using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class DFS
    {
        VertexScc[] _foundVertices;
        private int t;

        public void DepthSearch(GraphScc graph)
        {
            GraphHelper.SetVerticesUnfound(graph);
            _foundVertices = new VertexScc[graph.Vertices.Count];
            
            //Algorithm
            for (var i = 0; i < graph.Vertices.Count; i++)
            {
                if (!graph.Vertices[i].Found)
                    DepthSearchRecurse(graph, graph.Vertices[i]);
            }

            var invertedGraph = new GraphScc
                {
                    Edges = InvertEdges(graph),
                    Vertices = _foundVertices.ToList()
                };

            GraphHelper.SetVerticesUnfound(invertedGraph);

            var sccs = new List<List<VertexScc>>();
            t = 0;
            //Algorithm
            for (var i = 0; i < invertedGraph.Vertices.Count; i++)
            {
                if (!invertedGraph.Vertices[i].Found)
                {
                    DepthSearchRecurse(invertedGraph, invertedGraph.Vertices[i]);
                    var foundScc =
                        invertedGraph.Vertices.Where(v => v.Found && !sccs.Any(s => s.Any(vv => vv.ID == v.ID))).ToList();
                    sccs.Add(new List<VertexScc>(foundScc));
                }
            }

            t = 1;
            foreach (var scc in sccs.OrderBy(s => s.Count))
            {
                System.Console.WriteLine(string.Format("{0} component count: {1}", t, scc.Count));
            }
        }

        private List<EdgeScc> InvertEdges(GraphScc graph)
        {
            return graph.Edges.Select(edge => new EdgeScc
                {
                    StartPoint = edge.EndPoint, EndPoint = edge.StartPoint
                }).ToList();
        }

        private void DepthSearchRecurse(GraphScc graph, VertexScc node)
        {
            node.Found = true;
            
            var edges = graph.Edges.Where(e => e.StartPoint == node.ID).ToList();
            var counter = edges.Count;
            for (var i = 0; i < counter; i++)
            {
                var vertexId = edges[i].EndPoint;
                var vertex = graph.Vertices.FirstOrDefault(v => v.ID == vertexId);
                if (vertex != null && !vertex.Found)
                {
                    DepthSearchRecurse(graph, vertex);
                }
            }
            t++;
            DoSmth(node);
        }

        private void DoSmth(VertexScc vertex)
        {
            if (t%10 == 0)
            {
                Console.Write(t);
            }
            _foundVertices[t - 1] = new VertexScc(vertex.ID);
        }
    }
}
