using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class InsertionSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public InsertionSort(IEnumerable<T> items) : base(items) { }

        public InsertionSort() { }

        protected override void Sort()
        {
            int sortedIndex = 1;
            while (sortedIndex < Items.Count)
            {
                for (int i = sortedIndex - 1; i >= 0; i--)
                {
                    if (Compare(i, i + 1) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, i + 1);
                    }
                    else
                    {
                        break;
                    }
                }
                sortedIndex++;
            }
        }


    }
}
