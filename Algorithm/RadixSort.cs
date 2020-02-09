using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class RadixSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public bool IsMSD { get; private set; }

        public RadixSort()
        {
            IsMSD = true;
        }

        public RadixSort(bool isMSD)
        {
            IsMSD = isMSD;
        }

        public RadixSort(IEnumerable<T> items)
        {
            IsMSD = true;
            AddRange(items);
        }

        public RadixSort(IEnumerable<T> items, bool isMSD)
        {
            IsMSD = isMSD;
            AddRange(items);
        }

        public void AddRange(IEnumerable<T> items)
        {
            bool isCorrectValue = false;
            List<T> list = items.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType() == typeof(int))
                {
                    isCorrectValue = Convert.ToInt32(list[i]) > -1;
                }
                if (list[i].GetType() == typeof(string))
                {
                    isCorrectValue = Int32.TryParse(list[i].ToString(), out _);
                }
                if (isCorrectValue)
                {
                    Items.Add(list[i]);
                }
                else
                {
                    throw new ArrayTypeMismatchException();
                    break;
                }
            }
        }

        protected override void Sort()
        {
            List<T> buckets = Items;
            if (IsMSD)
            {
            }
            else
            {
                //Items = buckets;
                int maxLenght = Convert.ToString(buckets.Max()).Length;
                for (int i = 0; i < maxLenght; i++)
                {
                    buckets = GetFromLSDBucket(buckets, i);
                }
                Items = buckets;
            }
            if (!IsAscending)
            {
                Items.Reverse();
            }

        }

        private List<T> GetFromLSDBucket(List<T> items, int rank = 0)
        {
            List<T> result = new List<T>();
            List<T>[] bucket = new List<T>[10];
            for (int j = 0; j < bucket.Length; j++)
            {
                bucket[j] = new List<T>();
                for (int i = 0; i < items.Count; i++)
                {
                    if (GetRadix(Convert.ToInt32(items[i]), rank) == j)
                    {
                        bucket[j].Add(items[i]);
                    }
                }
                //bucket[j].Sort();
                result.AddRange(bucket[j]);
            }
            return result;
        }

        private int GetRadix(long number, int rank)
        {
            string value = number.ToString();
            //if (rank >= value.Length)
            //{
            //    throw new ArgumentOutOfRangeException();
            //}
            return rank >= value.Length ? 0 : Convert.ToInt32(value.Substring(value.Length - rank - 1, 1));
        }
    }
}
