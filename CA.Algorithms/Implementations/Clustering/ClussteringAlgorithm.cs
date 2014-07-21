using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.Clustering;
using CA.Algorithms.Data.UnionFind;

namespace CA.Algorithms.Implementations.Clustering
{
    public class ClussteringAlgorithm
    {
        public void GetSpacing(GraphKruskal graph, int numClusters)
        {
            var unionFind = new UnionFind<VertextKruskal>();

            foreach (var vertex in graph.Vertices)
            {
                unionFind.AddElement(vertex, vertex.Id);
            }

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                var leader1 = unionFind.GetClusterId(edge.Start).Value;
                var leader2 = unionFind.GetClusterId(edge.End).Value;
                if (leader1 != leader2)
                {
                    unionFind.MergeGroups(leader1, leader2);
                }

                if (unionFind.GroupsCount <= numClusters)
                {
                    break;
                }
            }

            var distances = new Dictionary<string, int>();
            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                var cluster1 = unionFind.GetClusterId(edge.Start).Value;
                var cluster2 = unionFind.GetClusterId(edge.End).Value;
                if (cluster1 != cluster2)
                {
                    var clusterDistanceKey = GetClusterDistanceKey(cluster1, cluster2);
                    if (!distances.ContainsKey(clusterDistanceKey))
                    {
                        distances.Add(clusterDistanceKey, int.MaxValue);
                    }

                    if (distances[clusterDistanceKey] > edge.Weight)
                    {
                        distances[clusterDistanceKey] = edge.Weight;
                    }
                }
            }

            foreach (var distance in distances.OrderBy(d => d.Value))
            {
                Console.WriteLine("{0} - {1}", distance.Key, distance.Value);
            }
        }

        private string GetClusterDistanceKey(int group1, int group2)
        {
            return string.Format("{0}-{1}", group1 > group2 ? group1 : group2, group1 < group2 ? group1 : group2);
        }

        public int GetClustersNumber(ClusteringItem[] items)
        {
            var unionFind = new UnionFind<ClusteringItem>();
            foreach (var item in items)
            {
                unionFind.AddElement(item, item.Id);
            }
            var measure = new SpeedMeasure.Measure("Test");

            measure.StartMeasure();

            //IClusteringItemComparer clusteringItemComparer = new ClusteringItemsComparer();
            IClusteringItemComparer clusteringItemComparer = new ClusteringItemsComparerDictionary();

            foreach (var clusteringItemsDistance in clusteringItemComparer.GetOrderedDistance(items))
            {
                var leader1 = unionFind.GetClusterId(clusteringItemsDistance.Start).Value;
                var leader2 = unionFind.GetClusterId(clusteringItemsDistance.End).Value;
                if (leader1 != leader2)
                {
                    unionFind.MergeGroups(leader1, leader2);
                }
            }
            measure.StopMeasureDisplay();

            return unionFind.GroupsCount;
        }
    }

    
}
