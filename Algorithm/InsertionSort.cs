using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class InsertionSort<T> : AlgorithmBase<T>
        where T : IComparable<T>
    {

        protected override void Sort()
        {
            int sortedCount = 0;

            while (sortedCount < Items.Count - 1)
            {
                for (int i = sortedCount; i >= 0; i--)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        SwapCount++;
                        ComparisonCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                sortedCount++;
            }


        }


    }
}
