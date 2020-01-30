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
            int sortedIndex;
            //int releasedIndex;                              // вариант со смещением и особождением позиции
            int step = Items.Count / 2;

            while (step > 0)
            {
                for (int offset = 0; offset < step; offset++)
                {
                    sortedIndex = offset;
                    while (sortedIndex + step < Items.Count)
                    {
                        //releasedIndex = -1;                 // вариант со смещением и особождением позиции
                        T aux = Items[sortedIndex + step];
                        for (int i = sortedIndex; i >= 0; i -= step)
                        {
                            if (Compare(Items[i], aux) == (IsAscending ? 1 : -1))
                            {
                                //releasedIndex = i;          // вариант со смещением и особождением позиции
                                ////Items[i + step] = Items[i]; // вариант со смещением и особождением позиции
                                ////SwapCount++;                // вариант со смещением и особождением позиции
                                //Swap(i, i + step, true);    // вариант со смещением и особождением позиции
                                Swap(i, i + step); // вариант с перестановкой Swap() в тестах выполняется дольше на 5-8мс (числа <1000 размер 10000)
                            }
                            else
                            {
                                break;
                            }
                        }
                        //if (releasedIndex > -1)             // вариант со смещением и особождением позиции
                        //{                                   // вариант со смещением и особождением позиции
                        //    Items[releasedIndex] = aux;     // вариант со смещением и особождением позиции
                        //}                                   // вариант со смещением и особождением позиции
                        sortedIndex += step;
                    }
                }
                step /= 2;
            }


        }



    }
}
