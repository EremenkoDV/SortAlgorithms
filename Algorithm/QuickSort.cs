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
            QuickSortItems(0, Items.Count - 1);
        }

        private void QuickSortItems(int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int partIndex = Partition(lowIndex, highIndex);
                QuickSortItems(lowIndex, partIndex - 1);
                QuickSortItems(partIndex + 1, highIndex);
            }
        }
        private int Partition(int lowIndex, int highIndex)
        {

            //int pivotIndex = highIndex;
            int pivotIndex = GetMedianIndex(lowIndex, highIndex);
            //int pivotIndex = (lowIndex + highIndex) / 2;
            int pivotIndex = new Random().Next(lowIndex, highIndex);
            int i = lowIndex - 1;
            int j = highIndex + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (Compare(i, pivotIndex) == (IsAscending ? -1 : 1));
                
                do
                {
                    j--;
                } while (Compare(pivotIndex, j) == (IsAscending ? -1 : 1));

                if (i >= j)
                {
                    return j;
                }

                Swap(i, j);
            }

        }

        private int GetMedianIndex(int lowIndex, int highIndex)
        {
            int[] pivotIndexes = new int[3] { lowIndex, (lowIndex + highIndex) / 2, highIndex };
            int[] pivots = GetIntValuesArray(pivotIndexes);
            double median = GetMidValue(pivots);
            int minIndex = 0;
            int value = (int)Math.Abs(median - pivots[0]);
            for (int i = 1; i < pivots.Length; i++)
            {
                if (value > (int)Math.Abs(median - pivots[i]))
                {
                    value = (int)Math.Abs(median - pivots[i]);
                    minIndex = i;
                }
            }
            return pivotIndexes[minIndex];
        }

        private static double GetMidValue(int[] arr)
        {
            double middle = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                middle += arr[i];
            }
            middle /= arr.Length;
            return middle;
        }

        private int[] GetIntValuesArray(int[] arr)
        {
            int[] items = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                items[i] = Convert.ToInt32(Items[arr[i]]);
            }
            return items;
        }
    }
}
