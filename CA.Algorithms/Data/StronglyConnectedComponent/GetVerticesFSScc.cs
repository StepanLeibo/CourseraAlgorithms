using System.Collections.Generic;
using System.IO;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public class GetVerticesFSScc:IGetVerteciesScc
    {
        public List<VertexEdgesScc> GetGraph()
        {
            var graph = new List<VertexEdgesScc>();

            for (int i = 0; i < 875714 + 1; i++)
            {
                graph.Add(i);
            }

            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\StronglyConnectedComponent\SCC.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    string[] splited = text.Split(' ');

                    int vertex;

                    if (int.TryParse(splited[0], out vertex))
                    {
                        for (var c = 1; c < splited.Length; c++)
                        {
                            int endpoint;
                            if (int.TryParse(splited[c], out endpoint))
                            {
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
