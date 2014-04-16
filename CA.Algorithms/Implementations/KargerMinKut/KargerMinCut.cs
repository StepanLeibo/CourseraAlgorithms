using System;
using System.Linq;
using CA.Algorithms.Data.KargerMinCut.Domain;

namespace CA.Algorithms.Implementations.KargerMinKut
{
    public class KargerMinCut : IKargerMinCut
    {
        public int MinCut(Graph graph)
        {
            return RemoveVertex(graph.Clone())/2;
        }

        private int RemoveVertex(object clone)
        {
            var graph = (Graph)clone;

            if(graph.Vertices.Count == 2)
            {
                return graph.Edges.Count;
            }

            Edge removedEdge = RemoveRandomEdge(graph);

            ClearEdges(graph, removedEdge);

            return RemoveVertex(graph);
        }

        private void ClearEdges(Graph graph, Edge removedEdge)
        {
            //remove endpoint vertex
            graph.Vertices.Remove(removedEdge.EndPoint);

            foreach(var edge in graph.Edges)
            {
                if(edge.EndPoint == removedEdge.EndPoint)
                {
                    edge.EndPoint = removedEdge.StartPoint;
                }
                if (edge.StartPoint == removedEdge.EndPoint)
                {
                    edge.StartPoint = removedEdge.StartPoint;
                }
            }

            var edgesToRemove = graph.Edges.Where(edge => edge.StartPoint == edge.EndPoint).ToList();

            foreach (var edge in edgesToRemove)
            {
                graph.Edges.Remove(edge);
            }
        }

        private Edge RemoveRandomEdge(Graph graph)
        {
            var rnd = new Random();

            var edge = graph.Edges[rnd.Next(graph.Edges.Count)];

            graph.Edges.Remove(edge);

            return edge;
        }
    }
}
