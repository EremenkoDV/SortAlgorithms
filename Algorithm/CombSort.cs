using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class CombSort<T> : AlgorithmBase<T>
        where T : IComparable
    {
        public CombSort(IEnumerable<T> items) : base(items) { }

        public CombSort() { }

        protected override void Sort()
        {
            bool wasSwapped;
            int count = 0;
            int step = Items.Count - 1;
            double factor = 1 / (1 - Math.Exp( -(Math.Sqrt(5) + 1) / 2));

            do
            {
                // Bubble Sort Method begin when step = 1
                wasSwapped = false;
                for (int i = step; i < Items.Count - count; i++)
                {
                    if (Compare(i - step, i) == (IsAscending ? 1 : -1))
                    {
                        Swap(i - step, i);
                        wasSwapped = true;
                    }
                }
                if ((int)(step / factor) > 0)
                {
                    step = (int)(step / factor);
                }
                else
                {
                    step = 1;
                    count++;
                }
            } while (wasSwapped || step > 1);
        }

    }
}
