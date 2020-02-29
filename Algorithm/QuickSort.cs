using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class QuickSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public QuickSort(IEnumerable<T> items) : base(items) { }

        public QuickSort() { }

        protected override void Sort()
        {
            GetSortedItems(Items.Count);
        }

        private void GetSortedItems(int pivot, int startIndex = 0)
        {
            //int pivot = items.Count;
            int i = startIndex;
            int j = startIndex + pivot < Items.Count ? startIndex + pivot : Items.Count - 1;
            if (i == j)
            {
                return;
            }
            pivot /= 2;
            if (pivot == 0)
            {
                pivot = i;
            }
            //int leftIndex, rightIndex, pivotIndex;
            while (i < pivot || j > pivot)
            {
                //leftIndex = Array.IndexOf(Items.ToArray(), items[i], startIndex, items.Count - 1);
                //rightIndex = Array.LastIndexOf(Items.ToArray(), items[j], startIndex + items.Count - 1, items.Count - 1);
                //pivotIndex = Array.IndexOf(Items.ToArray(), items[pivot], startIndex, items.Count - 1);
                if (i < pivot && Compare(i, pivot) == (IsAscending ? -1 : 1))
                {
                    i++;
                }
                else if (j > pivot && Compare(pivot, j) == (IsAscending ? -1 : 1))
                {
                    j--;
                }
                else if (i != j)
                {
                    Swap(i, j);
                    if (i < pivot)
                    {
                        i++;
                    }
                    if (j > pivot)
                    {
                        j--;
                    }
                }
                else
                {
                    break;
                }
            }
            GetSortedItems(pivot, startIndex + pivot);
            //if (pivot == Items.Count / 2)
            //{
            //    GetSortedItems(Items.Count, startIndex + pivot);
            //}
        }

    }
}
