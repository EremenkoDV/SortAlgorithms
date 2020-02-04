using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Heap<T> : AlgorithmBase<T>
        where T : IComparable
    {
        private int maxHeap => IsMaxHeap ? 1 : -1;

        public bool IsMaxHeap { get; private set; }

        public T Top => Items.Count > 0 ? Items[0] : default(T);

        public Heap(bool isMaxHeap = true)
        {
            IsMaxHeap = isMaxHeap;
            IsAscending = !isMaxHeap;
        }

        public Heap(IEnumerable<T> items, bool isMaxHeap = true) : base(items)
        {
            IsMaxHeap = isMaxHeap;
            IsAscending = !isMaxHeap;
            for (int i = 0; i < Items.Count; i++)
                Reorder(i);
        }

        public void Add(T data)
        {
            if (!(data is T))
                throw new Exception("Неверный параметр!");
            Items.Add(data);
            Reorder(Items.Count - 1);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            Items.AddRange(items);
            for (int i = 0; i < Items.Count; i++)
                Reorder(i);
        }

        public bool Remove(T data)
        {
            if (!(data is T))
                throw new Exception("Неверный параметр!");
            bool result = false;
            int index = Items.IndexOf(data);
            if (index >= 0)
            {
                int count = Items.Count;
                Items[index] = Items[Items.Count - 1];
                Items.RemoveAt(Items.Count - 1);
                result = count > Items.Count;
                Reorder(index, false);
            }
            return result;
        }

        public T GetTop()
        {
            T item = Items[0];
            Items[0] = Items[Items.Count - 1];
            //Swap(0, Items.Count - 1, true);
            Items.RemoveAt(Items.Count - 1);
            Reorder(0, false);
            return item;
        }

        private void Reorder(int index, bool isUp = true)
        {
            int upIndex = (int)(index - 1) / 2;
            int downIndex1 = 2 * index + 1;
            int downIndex2 = 2 * index + 2;
            int downIndex = downIndex1;
            if (downIndex2 < Items.Count && Compare(Items[downIndex2], Items[downIndex1]) == maxHeap)
            {
                downIndex = downIndex2;
            }
            foreach (int i in new int[2] { upIndex, downIndex })
            {
                if (i != index && i < Items.Count)
                {
                    if (Compare(Items[i], Items[index]) == (i == upIndex ? -1 * maxHeap : maxHeap))
                    {
                        Swap(i, index);
                        Reorder((isUp ? i == upIndex : i != upIndex) ? i : index, isUp);
                    }
                }
            }
        }

        protected override void Sort()
        {
            List<T> items = new List<T>();
            while (Items.Count > 0)
            {
                items.Add(GetTop());
            }
            Items.AddRange(items);

            //for (int i = 1; i < Items.Count - i; i++)
            //{
            //    Swap(i, Items.Count - i);
            //}
        }
    }

}
