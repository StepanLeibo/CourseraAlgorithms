using System;
using System.Collections.Generic;

namespace CA.Algorithms.Implementations.BinaryTree
{
    public class Heap<T> where T:IComparable
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
            int smalestIndex;
            int l = 2*(i + 1) - 1;
            int r = 2*(i + 1);

            if (l < data.Count && (data[l].CompareTo(data[i]) < 0))
            {
                smalestIndex = l;
            }
            else
            {
                smalestIndex = i;
            }

            if (r < data.Count && (data[r].CompareTo(data[i]) < 0))
            {
                smalestIndex = r;
            }

            if (smalestIndex != i)
            {
                T tmp = data[i];
                data[i] = data[smalestIndex];
                data[smalestIndex] = tmp;

                MinHeapify(smalestIndex);
            }
        }
        private void MaxHeapify(int i)
        {
            int bigestIndex;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1);

            if (l < data.Count && (data[l].CompareTo(data[i]) > 0))
            {
                bigestIndex = l;
            }
            else
            {
                bigestIndex = i;
            }

            if (r < data.Count && (data[r].CompareTo(data[i]) > 0))
            {
                bigestIndex = r;
            }

            if (bigestIndex != i)
            {
                T tmp = data[i];
                data[i] = data[bigestIndex];
                data[bigestIndex] = tmp;

                MaxHeapify(bigestIndex);
            }
        }
        #endregion

        private List<T> data = new List<T>();

        public void Insert(T item)
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
        }

        public T ExtractTop()
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
