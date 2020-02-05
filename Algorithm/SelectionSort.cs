using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class SelectionSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public SelectionSort() { }

        public SelectionSort(IEnumerable<T> items) : base(items) { }

        protected override void Sort()
        {
            for (int i = 0; i < Items.Count - 1; i++)
            {
                int extremeIndex = i;
                for (int j = i + 1; j < Items.Count; j++)
                {
                    if (Compare(extremeIndex, j) == (IsAscending ? 1 : -1))
                    {
                        extremeIndex = j;
                    }
                }
                Swap(i, extremeIndex);
            }
        }

    }
}
