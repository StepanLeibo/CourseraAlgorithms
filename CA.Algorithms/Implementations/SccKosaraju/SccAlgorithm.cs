using System;
using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.GraphObjects;
using SpeedMeasure;

namespace CA.Algorithms.Implementations.SccKosaraju
{
    public class SccAlgorithm
    {
        public void FindComponents(List<VertexWithEdges> graph)
        {
            var invertMeasure = new Measure("invert graph");
            invertMeasure.StartMeasure();
            var invertedGraph = GetInvertedGraph(graph);
            invertMeasure.StopMeasureDisplay();

            var foundVerticesFirstPass = new bool[graph.Count];
            var bypassOrder = new Stack<VertexWithEdges>();
            var firstSearchMeasure = new Measure("first dfs");
            firstSearchMeasure.StartMeasure();
            for (int v = 0; v < graph.Count; v++)
            {
                if(!foundVerticesFirstPass[v])
                {
                    DepthSearchRecurse(invertedGraph, v, foundVerticesFirstPass, bypassOrder, AddFoundVertex);
                }
            }
            firstSearchMeasure.StopMeasureDisplay();

            var foundVerticesSecondPass = new bool[graph.Count];
            var secondPassMeasure = new Measure("second pass");
            secondPassMeasure.StartMeasure();
            var components = new List<Stack<VertexWithEdges>>();
            while (bypassOrder.Any())
            {
                var vertex = bypassOrder.Pop();
                if (!foundVerticesSecondPass[vertex.Id])
                {
                    var scc = new Stack<VertexWithEdges>();
                    DepthSearchRecurse(graph, vertex.Id, foundVerticesSecondPass, scc, AddFoundVertex);

                    components.Add(scc);
                }
            }
            secondPassMeasure.StopMeasureDisplay();

            var topComponents = components.OrderByDescending(c => c.Count).Take(5);
            foreach (var component in topComponents)
            {
                Console.WriteLine(component.Count);
            }
        }

        private List<VertexWithEdges> GetInvertedGraph(List<VertexWithEdges> graph)
        {
            var invertedGraph = new List<VertexWithEdges>();
            for (int i = 0; i < graph.Count; i++)
            {
                invertedGraph.Add(new VertexWithEdges
                    {
                        Id = graph[i].Id
                    });
            }
            for (int v = 0; v < graph.Count; v++)
            {
                for (int e = 0; e < graph[v].Edges.Count; e++)
                {
                    invertedGraph[graph[v].Edges[e]].Edges.Add(graph[v].Id);
                }
            }

            return invertedGraph;
        }

        private void DepthSearchRecurse(List<VertexWithEdges> graph, int vId, bool[] foundVertices, Stack<VertexWithEdges> supportGraph, Action<VertexWithEdges, Stack<VertexWithEdges>> afterAction)
        {
            foundVertices[vId] = true;

            for (var i = 0; i < graph[vId].Edges.Count; i++)
            {
                if (!foundVertices[graph[vId].Edges[i]])
                {
                    DepthSearchRecurse(graph, graph[vId].Edges[i], foundVertices, supportGraph, afterAction);
                }
            }

            afterAction(graph[vId], supportGraph);
        }

        private void AddFoundVertex(VertexWithEdges vertex, Stack<VertexWithEdges> foundVertices)
        {
            foundVertices.Push(vertex);
        }
    }
}
