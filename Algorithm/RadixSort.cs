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
                if (Convert.ToInt32(list[i].ToString()).GetType() == typeof(int))
                {
                    isCorrectValue = true;
                }
                if (IsMSD && list[i].ToString().GetType() == typeof(string))
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
            result = GetFromBuckets(result);
            Items = result;
            if (!IsAscending)
            {
                Items.Reverse();
            }

        }

        private List<T> GetFromBuckets(List<T> items, int index = 0)
        {
            int count = 0;
            int numBucket = -1;
            int[] exchangeIndexes = new int[items.Count];
            List<T> result = new List<T>();
            List<T>[] buckets = new List<T>[IsMSD ? 255 : 10];
            for (int i = 0; i < items.Count; i++)
            {
                if (!IsMSD)
                {
                    numBucket = GetDigit(Convert.ToInt32(items[i]), index);
                }
                else
                {
                    numBucket = GetASCIICode(Convert.ToString(items[i]), index);
                }

                if (buckets[numBucket] == null)
                {
                    buckets[numBucket] = new List<T>();
                }
                buckets[numBucket].Add(items[i]);
                exchangeIndexes[i] = numBucket;
            }
            if (numBucket > -1)
            {
                for (numBucket = 0; numBucket < buckets.Length; numBucket++)
                {
                    if (buckets[numBucket] != null)
                    {
                        if (IsMSD)
                        {
                            if (buckets[numBucket].Count == 1)
                            {
                                result.AddRange(buckets[numBucket]);
                                if (++count == items.Count)
                                {
                                    break;
                                }
                            }
                            else if (buckets[numBucket].Count > 1)
                            {
                                result.AddRange(GetFromBuckets(buckets[numBucket], index + 1));
                                count += buckets[numBucket].Count;
                                if (count == items.Count)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (buckets[numBucket].Count > 0)
                            {
                                result.AddRange(buckets[numBucket]);

                                int oldIndex = Array.IndexOf(exchangeIndexes, numBucket);

                                if (count != oldIndex)
                                {
                                    Swap(count, oldIndex);

                                    int temp = exchangeIndexes[oldIndex];
                                    exchangeIndexes[oldIndex] = exchangeIndexes[count];
                                    exchangeIndexes[count] = temp;
                                }

                                count++;
                            }
                        }
                    }
                }
                if (!IsMSD)
                {
                    int maxLength = GetMaxLength(result);
                    for (int i = index + 1; i < maxLength; i++)
                    {
                        result = GetFromBuckets(result, i);
                    }

                }
            }
            return result;
        }

        private int GetMaxLength(List<T> items)
        {
            int length;
            int maxLength = 0;
            for (int i = 0; i < items.Count; i++)
            {
                length = items[i].ToString().Length;
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
            return maxLength;
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
            return result;
        }
    }
}
