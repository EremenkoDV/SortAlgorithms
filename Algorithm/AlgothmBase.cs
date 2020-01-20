using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class AlgothmBase<T>
        where T : IComparable<T>
    {

        public List<T> Items { get; set; } = new List<T>();

        protected void Swap(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                T temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
            }
        }

        //public void FillRandom(int count)
        //{
        //    Random rnd = new Random();
        //    for (int i = 0; i < count; i++)
        //    {
        //        Items.Add(rnd.Next(0, 100));
        //    }
        //}

        public virtual void Sort()
        {
            Items.Sort();
        }

    }
}
