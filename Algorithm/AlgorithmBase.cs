﻿using System;
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

        public AlgorithmBase() { }

        public AlgorithmBase(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        public event EventHandler<Tuple<T, T>> CompareEvent;

        public event EventHandler<Tuple<T, T>> SwapEvent;

        protected void Swap(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                T temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;

                SwapEvent?.Invoke(this, new Tuple<T, T>(Items[positionA], Items[positionB]));

                SwapCount++;
            }
        }

        protected int Compare(T first, T second)
        {
            CompareEvent?.Invoke(this, new Tuple<T, T>(first, second));
            ComparisonCount++;
            return first.CompareTo(second);
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
