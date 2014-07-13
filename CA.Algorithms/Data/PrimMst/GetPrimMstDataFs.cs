using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.PrimMst
{
    public class GetPrimMstDataFs : IGetPrimMstData
    {
        public List<VertexPrim> GetData()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\PrimMst\edges.txt"))
            {
                var graph = new List<VertexPrim>();

                var text = reader.ReadLine();
                
                // initialize graph size
                var sizes = text.Split(' ');
                var vertiesSize = int.Parse(sizes[0]);

                for (var i = 0; i < vertiesSize; i++)
                {
                    graph.Add(new VertexPrim(i));
                }

                text = reader.ReadLine();
                
                while (text != null)
                {
                    var edgeData = text.Split(' ');

                    var startVer = int.Parse(edgeData[0]);
                    var endVer = int.Parse(edgeData[1]);
                    var cost = int.Parse(edgeData[2]);

                    graph[startVer - 1].Edges.Add(new EdgePrim(endVer - 1, cost));
                    graph[endVer - 1].Edges.Add(new EdgePrim(startVer - 1, cost));

                    text = reader.ReadLine();
                }

                return graph;
            }
        }
    }
}
