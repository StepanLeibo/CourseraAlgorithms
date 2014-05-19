using CA.Algorithms.Implementations.BinaryTree;

namespace CA.Algorithms.Implementations.MedianMaintenance
{
    public class MedianMaintenanceAlgorith
    {
        private Heap<int> minHeap = new Heap<int>(true);
        private Heap<int> maxHeap = new Heap<int>(false);

        public int GetMedianWithNewItem(int newItem)
        {
            var maxHeapCount = maxHeap.Count;
            var minHeapCount = minHeap.Count;
            if (maxHeapCount > minHeapCount)
            {
                if (maxHeapCount > 0 && maxHeap.Peek() > newItem)
                {
                    var temp = maxHeap.ExtractTop();
                    maxHeap.Insert(newItem);
                    newItem = temp;
                }

                minHeap.Insert(newItem);
            }
            else
            {
                if (minHeapCount > 0 && minHeap.Peek() < newItem)
                {
                    var temp = minHeap.ExtractTop();
                    minHeap.Insert(newItem);
                    newItem = temp;
                }

                maxHeap.Insert(newItem);
            }

            return maxHeap.Peek();
        }
    }
}
