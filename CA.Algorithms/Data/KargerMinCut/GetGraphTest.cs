using System.Collections.Generic;
using CA.Algorithms.Data.KargerMinCut.Domain;

namespace CA.Algorithms.Data.KargerMinCut
{
    public class GetGraphTest : IGetGraphKarger
    {
        public GraphKmc GetGraph()
        {
            var graph = new GraphKmc
                              {
                                  Vertices = {1, 2, 3, 4},
                                  Edges = new List<EdgeKmc>
                                              {
                                                  new EdgeKmc
                                                      {
                                                          StartPoint = 1,
                                                          EndPoint = 2
                                                      },
                                                      new EdgeKmc
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 1
                                                      },
                                                  new EdgeKmc
                                                      {
                                                          StartPoint = 1,
                                                          EndPoint = 3
                                                      },
                                                      new EdgeKmc
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 1
                                                      },
                                                  new EdgeKmc
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 4
                                                      },
                                                      new EdgeKmc
                                                      {
                                                          StartPoint = 4,
                                                          EndPoint = 2
                                                      },
                                                  new EdgeKmc
                                                      {
                                                          StartPoint = 2,
                                                          EndPoint = 3
                                                      },
                                                      new EdgeKmc
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 2
                                                      },
                                                  new EdgeKmc
                                                      {
                                                          StartPoint = 3,
                                                          EndPoint = 4
                                                      },
                                                      new EdgeKmc
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
