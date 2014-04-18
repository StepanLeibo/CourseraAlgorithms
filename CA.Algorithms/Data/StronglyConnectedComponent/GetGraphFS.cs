using System.IO;
using CA.Algorithms.Data.StronglyConnectedComponent.Domain;

namespace CA.Algorithms.Data.StronglyConnectedComponent
{
    public class GetGraphFSScc : IGetGraphScc
    {
        public GraphScc GetGraph()
        {
            var graph = new GraphScc();

            using (TextReader reader = File.OpenText(@"C:\Users\Stepan.Leybo\Downloads\SCC.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    string[] splited = text.Split(' ');

                    int vertex;

                    if (int.TryParse(splited[0], out vertex))
                    {
                        //if(graph.Vertices.Count == 0 || graph.Vertices.Last().ID < vertex)
                          //  graph.Vertices.Add(vertex);

                        for (var c = 1; c < splited.Length; c++)
                        {
                            int endpoint;
                            if (int.TryParse(splited[c], out endpoint))
                            {
                                graph.Edges.Add(new EdgeScc
                                {
                                    StartPoint = vertex,
                                    EndPoint = endpoint
                                });
                            }
                        }
                    }

                    text = reader.ReadLine();
                }
            }
            for (int i = 0; i < 875714; i++)
            {
                graph.Vertices.Add(i+1);
            }
            return graph;
        }
    }
}
