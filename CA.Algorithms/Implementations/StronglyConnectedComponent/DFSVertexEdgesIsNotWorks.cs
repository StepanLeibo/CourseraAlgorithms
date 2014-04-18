using System;
using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Implementations.StronglyConnectedComponent
{
    public class DFSVertexEdgesIsNotWorks
    {
        List<VertexEdgesScc> _foundVertices = new List<VertexEdgesScc>{new VertexEdgesScc
            {
                Edges = new List<int>(),
                ID = 0,
                Found = true
            }};
        private int t = 0;
        private List<VertexEdgesScc> _scc;
        private Dictionary<int, int> _newVert;
 

        public void DepthSearch(List<VertexEdgesScc> graph)
        {
            GraphHelper.SetVerticesUnfound(graph);
            
            //Algorithm
            for (var i = 1; i < graph.Count; i++)
            {
                if (!graph[i].Found)
                    DepthSearchRecurse(graph, i, false);
            }

            _newVert = new Dictionary<int, int>();

            

            Console.WriteLine(string.Format("Invert started: {0}", DateTime.Now));
            for (int i = 1; i < _foundVertices.Count; i++)
            {
                _newVert.Add(_foundVertices[i].ID, i);
            }
            //foreach (var vertex in _foundVertices)
            //{
            //    _newVert.Add(vertex.ID, _foundVertices.IndexOf(vertex));
            //}
            Console.WriteLine(string.Format("Invert edges: {0}", DateTime.Now));
            InvertEdges(_foundVertices);
            Console.WriteLine(string.Format("Invert finished {0}", DateTime.Now));

            GraphHelper.SetVerticesUnfound(_foundVertices);

            _foundVertices[0].Found = true;

            SecondPass();
        }

        private void SecondPass()
        {
            Console.WriteLine("Second Pass");
            var sccs = new List<List<VertexEdgesScc>>();
            t = 0;
            //Algorithm
            for (var i = 1; i < _foundVertices.Count; i++)
            {
                if (!_foundVertices[i].Found)
                {
                    _scc = new List<VertexEdgesScc>();
                    DepthSearchRecurse(_foundVertices, i, true);
                    var sccVertex = new List<VertexEdgesScc>();
                    foreach (var scc in sccs)
                    {
                        sccVertex.AddRange(scc);
                    }
                    //var foundScc = 
                    //    _foundVertices.Where(v => v.Found && !sccs.Any(s => s.Any(vv => vv.ID == v.ID))).ToList();
                    //Console.WriteLine(string.Format("{0} ", _scc.Count));
                    sccs.Add(new List<VertexEdgesScc>(_scc));
                }
            }

            t = 1;
            foreach (var scc in sccs.OrderBy(s => s.Count))
            {
                System.Console.WriteLine(string.Format("{0} component count: {1}", t, scc.Count));
            }
        }

        private void InvertEdges(List<VertexEdgesScc> graph)
        {
            for (int i = 1; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].Edges.Count; j++)
                {
                    graph[_newVert[graph[i].Edges[j]]].Edges.Add(i);
                    graph[i].Edges.Remove(graph[i].Edges[j]);
                }
            }
        }

        private void DepthSearchRecurse(List<VertexEdgesScc> graph, int vId, bool secondPass)
        {
            graph[vId].Found = true;

            for (var i = 0; i < graph[vId].Edges.Count; i++)
            {
                if (!graph[graph[vId].Edges[i]].Found)
                {
                    DepthSearchRecurse(graph, graph[vId].Edges[i], secondPass);
                }
            }
            t++;
            if(!secondPass)
                DoSmth(graph[vId]);
            else
            {
                Scc(graph[vId]);
            }
        }

        private void Scc(VertexEdgesScc vertexEdgesScc)
        {
            _scc.Add(vertexEdgesScc);
        }

        private void DoSmth(VertexEdgesScc vertex)
        {
            if (t%1000 == 0)
            {
                Console.Write("{0} ",t/1000);
            }
            _foundVertices.Add(vertex);
        }
    }
}
