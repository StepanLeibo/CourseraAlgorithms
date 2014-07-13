using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.PrimMst;
using CA.Algorithms.Implementations.BinaryTree;

namespace CA.Algorithms.Implementations.PrimMst
{
    public class PrimAlgorithm
    {
        public int PathLength(List<VertexPrim> graph)
        {
            var notAddedDic = new Dictionary<int, int>();

            foreach (var vertex in graph)
            {
                notAddedDic.Add(vertex.Id, vertex.VertexCost);
            }

            int mstCost = 0;

            while (notAddedDic.Count > 0)
            {
                var extractedKey = SelectVertexKeyFromDictionary(notAddedDic);

                var extractedVertex = graph[extractedKey];
                
                for(var i = 0; i < extractedVertex.Edges.Count; i++)
                {
                    var extractedEdge = extractedVertex.Edges[i];

                    graph[extractedEdge.End].CrossEdges.Insert(new EdgePrim(extractedVertex.Id, extractedEdge.Cost));

                    if (notAddedDic.ContainsKey(extractedEdge.End))
                    {
                        notAddedDic[extractedEdge.End] = graph[extractedEdge.End].VertexCost;
                    }
                }

                mstCost += extractedVertex.VertexCost != int.MaxValue ? extractedVertex.VertexCost : 0;
                notAddedDic.Remove(extractedKey);
            }

            return mstCost;
        }

        private int SelectVertexKeyFromDictionary(Dictionary<int, int> notAddedDic)
        {
            return notAddedDic.OrderBy(v => v.Value).First().Key;
        }
    }
}
