using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class ShellSort<T> : AlgorithmBase<T>
        where T : IComparable
    {
        public ShellSort(IEnumerable<T> items) : base(items) { }

        public ShellSort() { }

        protected override void Sort()
        {
            int sorted;
            int step = Items.Count / 2;

            while (step > 0)
            {
                for (int offset = 0; offset < step; offset++)
                {
                    sorted = offset;
                    if (offset + step < Items.Count)
                    {
                        T aux = Items[offset + step];
                        for (int i = 0; i < Items.Count; i += step)
                        {
                            for (int j = sorted; j >= 0; j--)
                            {
                                if (Compare(Items[i + offset], aux) == (IsAscending ? 1 : -1))
                                {
                                    indexReleased = i;
                                    Items[i + 1] = Items[i];
                                    SwapCount++;
                                 }
                            }
                        }
                    }
                }
                step = step / 2;
            }


        }



    }
}
