using System.Collections.Generic;
using System.Linq;
using CA.Algorithms.Data.ShortestPathDijkstra.Domain;

namespace CA.Algorithms.Implementations.ShortestPathDijkstra
{
    public class Dijkstra
    {
        private const int Infinity = 1000000;

        struct Distance
        {
            public int VertId;
            public int Length;
            public bool Found;
            
        }

        public int[] Agorithm(List<VertexSp> vertices, int vertexId)
        {
            var distance = new Distance[vertices.Count];

            for (int i = 0; i < distance.Count(); i++)
            {
                distance[i].VertId = i;
                distance[i].Length = Infinity;
                distance[i].Found = false;
            }

            distance[vertexId].Length = 0;

            while (true)
            {
                int id = SelectNextVertext(distance);
                if (id == -1  || distance[id].Length == Infinity)
                    break;

                distance[id].Found = true;

                foreach (var edge in vertices[id].Edges)
                {
                    int altDist = distance[id].Length + edge.Weight;

                    if (altDist < distance[edge.EndPoint].Length)
                    {
                        distance[edge.EndPoint].Length = altDist;
                    }
                }
            }

            return distance.Select(d => d.Length).ToArray();
        }

        private int SelectNextVertext(Distance[] distance)
        {
            var val = distance.Where(d => !d.Found).OrderBy(d => d.Length).ToArray();
            if (val.Count() > 0)
            {
                return val[0].VertId;
            }
            else
            {
                return -1;
            }
        }
    }
}
