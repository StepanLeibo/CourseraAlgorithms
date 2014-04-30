using System;
using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class SccAlgorithm
    {
        public void FindSccs(List<VertexWithEdgesScc> graph)
        {
            SccGraphHelper.SetVerticesUnfound(graph);
            
            //Algorithm
            var dfsGraph = GetDfsGraph(graph);

            InvertGraph(dfsGraph);

            SccGraphHelper.SetVerticesUnfound(dfsGraph);

            dfsGraph[0].Found = true;

            var componentsList = FindComponents(dfsGraph);

            //print components
            int componentNumber = 1;
            foreach (var scc in componentsList.OrderBy(s => s.Count))
            {
                Console.WriteLine("{0} component count: {1}", componentNumber++, scc.Count);
            }
        }

        private void InvertGraph(List<VertexWithEdgesScc> dfsGraph)
        {
            var newVerticesOrder = new Dictionary<int, int>();

            Console.WriteLine("Invert started: {0}", DateTime.Now);
            for (int i = 1; i < dfsGraph.Count; i++)
            {
                newVerticesOrder.Add(dfsGraph[i].ID, i);
            }

            Console.WriteLine("Invert edges: {0}", DateTime.Now);
            InvertEdges(dfsGraph, newVerticesOrder);
            Console.WriteLine("Invert finished {0}", DateTime.Now);
        }

        private void InvertEdges(List<VertexWithEdgesScc> graph, Dictionary<int, int> newVerticesOrder)
        {
            for (int i = 1; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].Edges.Count; j++)
                {
                    graph[newVerticesOrder[graph[i].Edges[j]]].Edges.Add(i);
                    graph[i].Edges.Remove(graph[i].Edges[j]);
                }
            }
        }

        private List<VertexWithEdgesScc> GetDfsGraph(List<VertexWithEdgesScc> graph)
        {
            var foundVertices = new Stack<VertexWithEdgesScc>();
            for (var i = 0; i < graph.Count; i++)
            {
                if (!graph[i].Found)
                    DepthSearchRecurse(graph, i, foundVertices, AddFoundVertex);
            }

            return foundVertices.ToArray().ToList();
        }

        private IEnumerable<List<VertexWithEdgesScc>> FindComponents(List<VertexWithEdgesScc> foundVertices)
        {
            Console.WriteLine("FindComponents");
            var sccs = new List<List<VertexWithEdgesScc>>();
            //Algorithm
            for (var i = 0; i < foundVertices.Count; i++)
            {
                if (!foundVertices[i].Found)
                {
                    var scc = new Stack<VertexWithEdgesScc>();
                    DepthSearchRecurse(foundVertices, i, scc, GenerateScc);

                    sccs.Add(new List<VertexWithEdgesScc>(scc));
                }
            }

            return sccs;
        }

        private void DepthSearchRecurse(List<VertexWithEdgesScc> graph, int vId, Stack<VertexWithEdgesScc> supportGraph, Action<VertexWithEdgesScc, Stack<VertexWithEdgesScc>> afterAction)
        {
            graph[vId].Found = true;

            for (var i = 0; i < graph[vId].Edges.Count; i++)
            {
                if (!graph[graph[vId].Edges[i]].Found)
                {
                    DepthSearchRecurse(graph, graph[vId].Edges[i], supportGraph, afterAction);
                }
            }

            afterAction(graph[vId], supportGraph);
        }

        private int generateSccCounter = 0;
        private void GenerateScc(VertexWithEdgesScc vertexEdgesScc, Stack<VertexWithEdgesScc> scc)
        {
            generateSccCounter++;
            if (generateSccCounter%1000 == 0)
            {
                Console.WriteLine(generateSccCounter);
            }
            scc.Push(vertexEdgesScc);
        }

        private int foundCounter = 0;
        private void AddFoundVertex(VertexWithEdgesScc vertex, Stack<VertexWithEdgesScc> foundVertices)
        {
            foundCounter++;
            if (foundCounter%1000 == 0)
            {
                Console.WriteLine(foundCounter);
            }
            foundVertices.Push(vertex);
        }
    }
}
