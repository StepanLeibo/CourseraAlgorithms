using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.Clustering
{
    public class ClusteringData : IClusteringData
    {
        public GraphKruskal GetGraph()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\Clustering\Clustering1.txt"))
            {
                var graph = new GraphKruskal
                    {
                        Edges = new List<EdgeKruskal>(),
                        Vertices = new List<VertextKruskal>()
                    };

                var text = reader.ReadLine();

                // initialize graph size
                var vertiesSize = int.Parse(text);

                for (var i = 0; i < vertiesSize; i++)
                {
                    graph.Vertices.Add(new VertextKruskal(i));
                }

                text = reader.ReadLine();

                while (text != null)
                {
                    var edgeData = text.Split(' ');

                    var startVer = int.Parse(edgeData[0]);
                    var endVer = int.Parse(edgeData[1]);
                    var weight = int.Parse(edgeData[2]);

                    graph.Edges.Add(new EdgeKruskal(startVer - 1, endVer - 1, weight));

                    text = reader.ReadLine();
                }

                return graph;
            }
        }
    }
}
