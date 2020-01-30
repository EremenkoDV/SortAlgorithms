using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class InsertionSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public InsertionSort(IEnumerable<T> items) : base(items) { }

        public InsertionSort() { }

        protected override void Sort()
        {
            int sortedIndex = 0;
            //int releasedIndex;                     // вариант со смещением и особождением позиции
            while (sortedIndex + 1 < Items.Count)
            {
                //releasedIndex = -1;                // вариант со смещением и особождением позиции
                T aux = Items[sortedIndex + 1];
                for (int i = sortedIndex; i >= 0; i--)
                {
                    if (Compare(Items[i], aux) == (IsAscending ? 1 : -1))
                    {
                        //releasedIndex = i;          // вариант со смещением и особождением позиции
                        ////Items[i + 1] = Items[i];
                        ////SwapCount++;
                        //Swap(i, i + 1, true);       // вариант со смещением и особождением позиции
                        Swap(i, i + 1);
                    }
                    else
                    {
                        break;
                    }
                }
                //if (releasedIndex > -1)              // вариант со смещением и особождением позиции
                //{                                    // вариант со смещением и особождением позиции
                //    Items[releasedIndex] = aux;      // вариант со смещением и особождением позиции
                //}                                    // вариант со смещением и особождением позиции
                sortedIndex++;
            }


        }


    }
}
