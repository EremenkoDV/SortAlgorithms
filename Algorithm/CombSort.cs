using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class CombSort<T> : AlgorithmBase<T>
        where T : IComparable
    {
        public CombSort(IEnumerable<T> items) : base(items) { }

        public CombSort() { }

        protected override void Sort()
        {
            int sortedIndex;
            int step = Items.Count / 2;
            double factor = 1 / (1 - Math.Exp(-(Math.Sqrt(5) - 1) / 2));

            while (step > 0)
            {
                for (int offset = 0; offset < step; offset++)
                {
                    // Insertion Sort Method for each offset begin 
                    sortedIndex = offset;
                    while (sortedIndex + step < Items.Count)
                    {
                        for (int i = sortedIndex; i >= 0; i -= step)
                        {
                            if (Compare(i, i + step) == (IsAscending ? 1 : -1))
                            {
                                Swap(i, i + step);
                            }
                            else
                            {
                                break;
                            }
                        }
                        sortedIndex += step;
                    }
                    // Insertion Sort Method for each offset end
                }
                step /= 2;
            }


        }



    }
}
