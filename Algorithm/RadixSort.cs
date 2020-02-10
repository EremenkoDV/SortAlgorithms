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

        public override void AddRange(IEnumerable<T> items)
        {
            bool isCorrectValue = false;
            List<T> list = items.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType() == typeof(int))
                {
                    isCorrectValue = Convert.ToInt32(list[i]) > -1;
                }
                if (IsMSD && list[i].GetType() == typeof(string))
                {
                    isCorrectValue = true;
                }
                if (isCorrectValue)
                {
                    Items.Add(list[i]);
                }
                else
                {
                    throw new ArrayTypeMismatchException();
                }
            }
        }

        protected override void Sort()
        {
            List<T> result = Items;
            //int maxLength = Convert.ToString(result.Max()).Length;
            int length = 0;
            int maxLength = 0;
            for (int i = 0; i < result.Count; i++)
            {
                length = Convert.ToString(result[i]).Length;
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
            ////int index = IsMSD ? maxLength - 1 : 0;
            ////while (index >= 0 && index < maxLength)
            //for (int index = 0; index < maxLength; index++)
            {
                //result = GetFromBuckets(result, index);
                result = GetFromBuckets(result, maxLength);
                ////index = IsMSD ? index - 1 : index + 1;
            }
            Items = result;
            if (!IsAscending)
            {
                Items.Reverse();
            }

        }

        //private List<T> GetFromBuckets(List<T> items, int index = 0)
        private List<T> GetFromBuckets(List<T> items, int maxLength, int index = 0)
        {
            List<T> result = new List<T>();
            List<T>[] buckets = new List<T>[IsMSD ? 255 : 10];
            while (index < maxLength)
            {
                for (int numBucket = 0; numBucket < buckets.Length; numBucket++)
                {
                    buckets[numBucket] = new List<T>();
                    for (int i = 0; i < items.Count; i++)
                    {
                        if ((!IsMSD && GetDigit(Convert.ToInt32(items[i]), index) == numBucket) ||
                            (IsMSD && GetASCIICode(Convert.ToString(items[i]), index) == numBucket))
                        {
                            buckets[numBucket].Add(items[i]);
                            Swap(i, buckets[numBucket].Count - 1);
                        }
                    }
                    //result.AddRange(buckets[numBucket]);
                    if (buckets[numBucket].Count == 1)
                    {
                        result.AddRange(buckets[numBucket]);
                    }
                    else if (buckets[numBucket].Count > 1)
                    {
                        result.AddRange(GetFromBuckets(buckets[numBucket], maxLength, ++index));
                    }
                }
            }
            return result;
        }

        private int GetDigit(long number, int index)
        {
            string value = number.ToString();
            return index >= 0 && index < value.Length ? Convert.ToInt32(value.Substring(value.Length - index - 1, 1)) : 0;
        }

        private int GetASCIICode(string wordOrNumber, int index)
        {
            int result = 0;
            if (index >= 0 && index < wordOrNumber.Length)
            {
                byte[] bytes = new byte[1];
                if (Encoding.ASCII.GetBytes(wordOrNumber, index, 1, bytes, 0) == 1)
                {
                    result = bytes[0];
                }
            }
            //return index >= 0 && index < wordOrNumber.Length ? Encoding.ASCII.GetBytes(wordOrNumber, wordOrNumber.Length - index - 1, 1, bytes, 0) : 0;
            return result;
        }
    }
}
