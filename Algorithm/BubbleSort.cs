using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BubbleSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public BubbleSort(IEnumerable<T> items) : base(items) { }

        public BubbleSort() { }

        protected override void Sort()
        {
            bool wasSwapped;
            int count = Items.Count;
            do
            {
                wasSwapped = false;
                for (int i = 0; i < count - 1; i++)
                {
                    if (Compare(i, i + 1) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, i + 1);
                        wasSwapped = true;
                    }
                }
                count--;
            } while (wasSwapped);
        }

    }
}
