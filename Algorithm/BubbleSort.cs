using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BubbleSort<T> : AlgothmBase<T>
        where T : IComparable<T>
    {

        public override void Sort()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = i; j < Items.Count; j++)
                {
                    if (Items[i].CompareTo(Items[j]) == -1)
                    {
                        Swap(i, j);
                    }
                }
            }
        }

    }
}
