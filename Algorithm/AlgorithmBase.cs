using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithm
{
    public class AlgorithmBase<T>
        where T : IComparable
    {

        public int SwapCount { get; protected set; } = 0;

        public int ComparisonCount { get; protected set; } = 0;

        public List<T> Items { get; set; } = new List<T>();

        public bool IsAscending { get; set; } = true;

        public AlgorithmBase() { }

        public AlgorithmBase(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        public event EventHandler<Tuple<T, T>> CompareEvent;

        public event EventHandler<Tuple<T, T>> SwapEvent;

        public event EventHandler<T> RemoveEvent;

        protected void Swap(int index1, int index2)
        {
            if (index1 < Items.Count && index2 < Items.Count)
            {
                SwapEvent?.Invoke(this, new Tuple<T, T>(Items[index1], Items[index2]));
                T temp = Items[index1];
                Items[index1] = Items[index2];
                Items[index2] = temp;
                SwapCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        protected void InsertAt(int index1, int index2)
        {
            if (index1 < Items.Count && index2 < Items.Count)
            {
                int step = index1 > index2 ? 1 : -1;
                for (int i = index2; index1 > index2 ? i < index1 : i > index1; i += step)
                {
                    SwapEvent?.Invoke(this, new Tuple<T, T>(Items[i + step], Items[i]));
                    T temp = Items[i + step];
                    Items[i + step] = Items[i];
                    Items[i] = temp;
                }

                SwapCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        protected int Compare(int index1, int index2)
        {
            if (index1 < Items.Count && index2 < Items.Count)
            {
                CompareEvent?.Invoke(this, new Tuple<T, T>(Items[index1], Items[index2]));
                ComparisonCount++;
                return Items[index1].CompareTo(Items[index2]);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        protected void RemoveAt(int index)
        {
            if (index < Items.Count)
            {
                RemoveEvent?.Invoke(this, Items[index]);
                Items.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
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
