using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithm
{
    public class AlgorithmBase<T>
        where T : IComparable<T>
    {

        public int SwapCount { get; protected set; } = 0;

        public int ComparisonCount { get; protected set; } = 0;

        public List<T> Items { get; set; } = new List<T>();

        public bool IsAscending { get; set; } = true;

        protected void Swap(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                T temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;

                SwapCount++;
            }
        }

        public TimeSpan SortAndGetSpan()
        {
            SwapCount = 0;
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Sort();
            timer.Stop();

            return timer.Elapsed;
        }

        protected virtual void Sort()
        {
            Items.Sort();
        }

    }
}
