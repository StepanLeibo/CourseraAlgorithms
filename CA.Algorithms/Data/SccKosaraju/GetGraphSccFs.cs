using System.Collections.Generic;
using System.IO;
using CA.Algorithms.Data.GraphObjects;

namespace CA.Algorithms.Data.SccKosaraju
{
    public class GetGraphSccFs : IGetGraphScc
    {
        public List<VertexWithEdges> GetGraph()
        {
            var graph = new List<VertexWithEdges>();

            for (int i = 0; i < 875714 + 1; i++)
            {
                graph.Add(new VertexWithEdges
                {
                    Id = i
                });
            }

            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\SccKosaraju\SCC.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    string[] splited = text.Split(' ');

                    int vertex;

                    if (int.TryParse(splited[0], out vertex))
                    {
                        vertex -= 1;
                        for (var c = 1; c < splited.Length; c++)
                        {
                            int endpoint;
                            if (int.TryParse(splited[c], out endpoint))
                            {
                                endpoint -= 1;
                                graph[vertex].Edges.Add(endpoint);
                            }
                        }
                    }

                    text = reader.ReadLine();
                }
            }

            //graph.RemoveAll(v => v.Edges.Count == 0);

            return graph;
        }
    }
}
