using System.IO;
using CA.Algorithms.Data.KargerMinCut.Domain;

namespace CA.Algorithms.Data.KargerMinCut
{
    public class GetGraphFS:IGetGraphKarger
    {
        public GraphKmc GetGraph()
        {
            var graph = new GraphKmc();

            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\KargerMinCut\kargerMinCut.txt"))
            {
                string text = reader.ReadLine();
                while(text != null)
                {
                    string[] splited = text.Split('\t');

                    int vertex;

                    if (int.TryParse(splited[0], out vertex))
                    {
                        graph.Vertices.Add(vertex);

                        for(var c = 1; c < splited.Length; c++)
                        {
                            int endpoint;
                            if(int.TryParse(splited[c], out endpoint))
                            {
                                graph.Edges.Add(new EdgeKmc
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

            return graph;
        }
    }
}
