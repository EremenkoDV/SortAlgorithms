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

        public InsertionSort(IEnumerable<T> items) : base(items) { }

        public InsertionSort() { }

        protected override void Sort()
        {
            int sortedCount = 0;
            int indexReleased;
            while (sortedCount < Items.Count - 1)
            {
                indexReleased = -1;
                T aux = Items[sortedCount + 1];
                for (int i = sortedCount; i >= 0; i--)
                {
                    if (Compare(Items[i], aux) == (IsAscending ? 1 : -1))
                    {
                        //Swap(i, i + 1);
                        indexReleased = i;
                        Items[i + 1] = Items[i];
                        SwapCount++;
                        //ComparisonCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (indexReleased > -1)
                {
                    Items[indexReleased] = aux;
                }
                sortedCount++;
            }


        }


    }
}
