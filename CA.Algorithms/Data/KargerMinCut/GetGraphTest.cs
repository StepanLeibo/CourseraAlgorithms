using System.Collections.Generic;
using CA.Algorithms.Data.KargerMinCut.Domain;

namespace CA.Algorithms.Data.KargerMinCut
{
    public class GetGraphTest : IGetGraphKarger
    {
        public Graph GetGraph()
        {
            var graph = new Graph
                              {
                                  Vertices = {1, 2, 3, 4},
                                  Edges = new List<Edge>
                                              {
                                                  new Edge
                                                      {
                                                          StartPoint = 1,
                                                          EndPoint = 2
                                                      },
                                                      new Edge
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 1
                                                      },
                                                  new Edge
                                                      {
                                                          StartPoint = 1,
                                                          EndPoint = 3
                                                      },
                                                      new Edge
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 1
                                                      },
                                                  new Edge
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 4
                                                      },
                                                      new Edge
                                                      {
                                                          StartPoint = 4,
                                                          EndPoint = 2
                                                      },
                                                  new Edge
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 3
                                                      },
                                                      new Edge
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 2
                                                      },
                                                  new Edge
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 4
                                                      },
                                                      new Edge
                                                      {
                                                          StartPoint = 4,
                                                          EndPoint = 3
                                                      }
                                              }
                              };
            return graph;
        }
    }
}
