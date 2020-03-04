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
            QuickSort2Items(0, Items.Count - 1);
        }

        private void QuickSort2Items(int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int pivotIndex = GetPivotIndex(lowIndex, highIndex);
                QuickSort2Items(lowIndex, pivotIndex - 1);
                QuickSort2Items(pivotIndex + 1, highIndex);
            }
        }
        private int GetPivotIndex(int lowIndex, int highIndex)
        {
            // highIndex - pivotIndex
            int pointIndex = lowIndex;
            for (int i = lowIndex; i < highIndex; i++)
            {
                if (Compare(i, highIndex) == (IsAscending ? -1 : 1))
                {
                    Swap(pointIndex, i);
                    pointIndex++;
                }
            }
            Swap(pointIndex, highIndex);
            return pointIndex;
        }

    }
}
