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

        public SelectionSort(IEnumerable<T> items) : base(items)
        {

        }

        protected override void Sort()
        {
            
            for (int i = 0; i < Items.Count; i++)
            {

                for (int j = i; j < Items.Count; j++)
                {
                    if (Compare(Items[i], Items[j]) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, j);
                    }
                }

            }

        }

    }
}
