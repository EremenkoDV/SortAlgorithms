using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class OddEvenSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public OddEvenSort(IEnumerable<T> items) : base(items) { }

        public OddEvenSort() { }

        protected override void Sort()
        {
            bool wasSwapped;
            int oddEven = 0;
            do
            {
                wasSwapped = false;
                for (int i = oddEven; i < Items.Count - 1; i += 2)
                {
                    if (Compare(i, i + 1) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, i + 1);
                        wasSwapped = true;
                    }
                }
                oddEven = (oddEven + 1) % 2;
            } while (wasSwapped);
        }

    }
}
