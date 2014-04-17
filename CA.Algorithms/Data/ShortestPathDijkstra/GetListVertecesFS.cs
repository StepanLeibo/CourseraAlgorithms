using System.Collections.Generic;
using System.IO;
using System.Linq;
using CA.Algorithms.Data.ShortestPathDijkstra.Domain;

namespace CA.Algorithms.Data.ShortestPathDijkstra
{
    public class GetListVertecesFS : IGetListVertexes
    {
        public List<VertexSp> GetVerteces()
        {
            var vertices = new List<VertexSp> { new VertexSp() };

            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\ShortestPathDijkstra\dijkstraData.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    string[] splited = text.Split('\t');
                    int vertexId;
                    var vertex = new VertexSp();

                    if (int.TryParse(splited[0], out vertexId))
                    {
                        vertex.ID = vertexId;

                        for (var c = 1; c < splited.Length; c++)
                        {
                            var edge = splited[c].Split(',');
                            if (edge.Count() == 2)
                            {
                                int endpoint;
                                int weight;
                                if (int.TryParse(edge[0], out endpoint) && int.TryParse(edge[1], out weight))
                                {
                                    vertex.Edges.Add(new EdgeSp
                                        {
                                            StartPoint = vertexId,
                                            EndPoint = endpoint,
                                            Weight = weight
                                        });
                                }
                            }
                        }

                        vertices.Add(vertex);
                    }

                    text = reader.ReadLine();
                }
            }

            return vertices;
        }
    }
}
