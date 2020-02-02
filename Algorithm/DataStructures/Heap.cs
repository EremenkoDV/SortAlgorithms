using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Heap<T> where T : IComparable
    {
        private List<T> items = new List<T>();

        private int maxHeap => IsMaxHeap ? 1 : -1;

        public bool IsMaxHeap { get; private set; }

        public int Count => items.Count;

        public T Top => Count > 0 ? items[0] : default(T);

        public Heap(bool isMaxHeap = true)
        {
            IsMaxHeap = isMaxHeap;
        }

        public Heap(IEnumerable<T> items, bool isMaxHeap = true) : this(isMaxHeap)
        {
            this.items.AddRange(items);
            for (int i = 0; i < Count; i++)
                Reorder(i);
        }

        public void Add(T data)
        {
            if (!(data is T))
                throw new Exception("Неверный параметр!");
            items.Insert(0, data);
            Reorder(0);
        }

        public bool Remove(T data)
        {
            if (!(data is T))
                throw new Exception("Неверный параметр!");
            bool result = false;
            int index = items.IndexOf(data);
            if (index >= 0)
            {
                //result = items.Remove(data);
                int count = Count;
                items[index] = items[Count - 1];
                items.RemoveAt(Count - 1);
                result = count > Count;
                Reorder(index);
            }
            return result;
        }

        public T GetTop()
        {
            T item = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Reorder(0);
            //if (!Remove(item))
            //    throw new Exception("Куча пустая!");
            return item;
        }

        private void Reorder(int index)
        {
            int upIndex = (int)(index - 1) / 2;
            int downIndex1 = 2 * index + 1;
            int downIndex2 = 2 * index + 2;
            int downIndex = downIndex1;
            if (downIndex1 < Count)
            {
                if (downIndex2 < Count && items[downIndex2].CompareTo(items[downIndex1]) == maxHeap)
                {
                    downIndex = downIndex2;
                }
                foreach (int i in new int[2] { upIndex, downIndex })
                {
                    if (i != index && i < Count)
                    {
                        if (items[i].CompareTo(items[index]) == (i == upIndex ? -1 * maxHeap : maxHeap))
                        {
                            Swap(i, index);
                            Reorder(i);
                        }
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T aux = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = aux;
        }

        public List<T> GetSortedList()
        {
            List<T> result = new List<T>();
            while (Count > 0)
            {
                result.Add(GetTop());
            }
            return result;
        }
    }

}
