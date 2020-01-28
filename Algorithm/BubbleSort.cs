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
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = i + 1; j < Items.Count; j++)
                {
                    if (Compare(Items[i], Items[j]) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, j);
                    }
                    //System.Threading.Thread.Sleep(500);
                }
            }
        }

    }
}
