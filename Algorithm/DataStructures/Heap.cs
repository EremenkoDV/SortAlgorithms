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

        public bool IsMaxHeap => !IsAscending;

        public T Top => Items.Count > 0 ? Items[0] : default(T);

        public Heap() { }

        public Heap(IEnumerable<T> items) : base(items)
        {
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

        public T GetTop()
        {
            T item = Items[0];
            Swap(0, Items.Count - 1);
            RemoveAt(Items.Count - 1);
            Reorder(0, false);
            return item;
        }

        private void Reorder(int index, bool isUp = true)
        {
            int upIndex = (int)(index - 1) / 2;
            int downIndex1 = 2 * index + 1;
            int downIndex2 = 2 * index + 2;
            int downIndex = downIndex1;
            if (downIndex2 < Items.Count && Compare(downIndex2, downIndex1) == maxHeap)
            {
                downIndex = downIndex2;
            }
            foreach (int i in new int[2] { upIndex, downIndex })
            {
                if (i != index && i < Items.Count)
                {
                    if (Compare(i, index) == (i == upIndex ? -1 * maxHeap : maxHeap))
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
        }
    }

}
