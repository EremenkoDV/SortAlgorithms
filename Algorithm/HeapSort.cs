using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class HeapSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public HeapSort() { }

        public HeapSort(IEnumerable<T> items) : base(items) { }

        protected override void Sort()
        {
            DataStructures.Heap<T> heap = new DataStructures.Heap<T>(Items);

            Items = heap.GetSortedList();
        }

    }
}
