using System.Collections.Generic;

using CA.Algorithms.Data.Clustering;

namespace CA.Algorithms.Implementations.Clustering
{
    public interface IClusteringItemComparer
    {
        IEnumerable<ClusterItemsDistance> GetOrderedDistance(ClusteringItem[] items);
    }
}
