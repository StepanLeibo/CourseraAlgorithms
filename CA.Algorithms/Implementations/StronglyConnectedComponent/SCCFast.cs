using System;
using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class SCCFast
    {
        private List<List<VertexEdgesScc>> _output;
        private Stack<int> _stack;
        private int _index;
        private int _sccCounter = 0;

        public List<List<VertexEdgesScc>> StronglyConnectedComponents(List<VertexEdgesScc> graph)
        {
            _output = new List<List<VertexEdgesScc>>();
            _stack = new Stack<int>();
            _index = 1;

            GraphHelper.SetVerticesUnfound(graph);

            for(var i = 1; i < graph.Count; i++)
            {
                if (!graph[i].Found)
                    DepthFirstSearch(graph, i);
            }

            foreach (var scc in _output.OrderBy(s => s.Count))
            {
                Console.WriteLine(scc.Count);
            }

            return _output;
        }

        private void DepthFirstSearch(List<VertexEdgesScc> graph, int i)
        {
            graph[i].Found = true;
            _stack.Push(graph[i].ID);

            graph[i].Index = _index;
            graph[i].LowLink = _index;
            _index++;

            for (int j = 0; j < graph[i].Edges.Count; j++ )
            {
                if (graph[graph[i].Edges[j]].Index < 0)
                {
                    DepthFirstSearch(graph, graph[i].Edges[j]);
                    graph[i].LowLink = Math.Min(graph[i].LowLink, graph[graph[i].Edges[j]].LowLink);
                }
                else if (_stack.Contains(graph[graph[i].Edges[j]].ID))
                {
                    graph[i].LowLink = Math.Min(graph[i].LowLink, graph[graph[i].Edges[j]].Index);
                }
            }

            if(graph[i].LowLink == graph[i].Index)
            {
                var scc = new List<VertexEdgesScc>();
                int vertexId;
                do
                {
                    vertexId = _stack.Pop();
                    scc.Add(graph[vertexId]);
                } while (graph[i].ID != vertexId);
                _output.Add(scc);
                _sccCounter += scc.Count;
                Console.WriteLine(_sccCounter);
            }
        }
    }
}
