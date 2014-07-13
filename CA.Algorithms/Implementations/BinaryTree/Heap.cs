using System;
using System.Collections.Generic;

namespace CA.Algorithms.Implementations.BinaryTree
{
    public class Heap<T> where T:IComparable<T>
    {
        #region Constructor
        public Heap(bool isMinHeap)
        {
            if (isMinHeap)
            {
                stopBubleUp = StopMinHeapBubbleUp;
                heapify = MinHeapify;
            }
            else
            {
                stopBubleUp = StopMaxHeapBubbleUp;
                heapify = MaxHeapify;
            }
        }

        private delegate bool StopBubleUp(T parent, T child);
        private StopBubleUp stopBubleUp;
        private bool StopMinHeapBubbleUp(T parent, T child)
        {
            return parent.CompareTo(child) <= 0;
        }
        private bool StopMaxHeapBubbleUp(T parent, T child)
        {
            return parent.CompareTo(child) >= 0;
        }

        private delegate void Heapify(int top);
        private Heapify heapify;

        private void MinHeapify(int i)
        {
            int smallestIndex;
            int l = 2*(i + 1) - 1;
            int r = 2*(i + 1);

            if (l < data.Count && (data[l].CompareTo(data[i]) < 0))
            {
                smallestIndex = l;
            }
            else
            {
                smallestIndex = i;
            }

            if (r < data.Count && (data[r].CompareTo(data[smallestIndex]) < 0))
            {
                smallestIndex = r;
            }

            if (smallestIndex != i)
            {
                T tmp = data[i];
                data[i] = data[smallestIndex];
                data[smallestIndex] = tmp;

                MinHeapify(smallestIndex);
            }
        }
        private void MaxHeapify(int i)
        {
            int biggestIndex;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1);

            if (l < data.Count && (data[l].CompareTo(data[i]) > 0))
            {
                biggestIndex = l;
            }
            else
            {
                biggestIndex = i;
            }

            if (r < data.Count && (data[r].CompareTo(data[biggestIndex]) > 0))
            {
                biggestIndex = r;
            }

            if (biggestIndex != i)
            {
                T tmp = data[i];
                data[i] = data[biggestIndex];
                data[biggestIndex] = tmp;

                MaxHeapify(biggestIndex);
            }
        }
        #endregion

        protected List<T> data = new List<T>();

        public virtual void Insert(T item)
        {
            data.Add(item);

            int itemInd = data.Count - 1;
            while (itemInd > 0)
            {
                int parentInd = (itemInd + 1)/2 - 1;

                T parent = data[parentInd];

                if (stopBubleUp(parent, item))
                {
                    break;
                }

                T tmp = data[itemInd];
                data[itemInd] = data[parentInd];
                data[parentInd] = tmp;

                itemInd = parentInd;
            }

            heapify(0);
        }

        public virtual T ExtractTop()
        {
            if (data.Count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T top = data[0];
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            heapify(0);

            return top;
        }

        public T Peek()
        {
            return data[0];
        }

        public int Count
        {
            get { return data.Count; }
        }
    }
}
