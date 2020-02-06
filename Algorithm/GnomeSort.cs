using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class GnomeSort<T> : AlgorithmBase<T>
        where T : IComparable
    {
        public GnomeSort() { }

        public GnomeSort(IEnumerable<T> items) : base(items) { }

        protected override void Sort()
        {
            int i = 0;
            while (i < Items.Count - 1)
            {
                if (Compare(i, i + 1) == (IsAscending ? 1 : -1))
                {
                    Swap(i, i + 1);
                    if (i > 0)
                    {
                        i--;
                    }
                }
                else
                {
                    i++;
                }
            }
        }


    }
}
