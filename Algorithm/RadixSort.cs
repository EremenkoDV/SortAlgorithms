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
        public bool IsMSD { get; set; }

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
                if (Convert.ToInt32(list[i]).GetType() == typeof(int))
                {
                    isCorrectValue = Convert.ToInt32(list[i]) >= 0;
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
            Items = GetFromBuckets(Items);
        }

        private List<T> GetFromBuckets(List<T> items, int index = 0)
        {
            int numBucket = -1;
            List<T> result = new List<T>();
            Dictionary<int, List<T>> buckets = new Dictionary<int, List<T>>();
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

                if (!buckets.ContainsKey(numBucket))
                {
                    buckets.Add(numBucket, new List<T>());
                }
                buckets[numBucket].Add(items[i]);
            }
            if (numBucket > -1)
            {
                int count = 0;
                int countBuckets = 0;
                numBucket = IsAscending ? 0 : 255;
                while (countBuckets < buckets.Count)
                {
                    if (buckets.ContainsKey(numBucket))
                    {
                        if (IsMSD)
                        {
                            if (buckets[numBucket].Count > 1 && index + 1 < GetMaxLength(buckets[numBucket]))
                            {
                                result.AddRange(GetFromBuckets(buckets[numBucket], index + 1));
                            }
                            else
                            {
                                result.AddRange(buckets[numBucket]);
                            }
                            //count += buckets[numBucket].Count;
                        }
                        else
                        {
                            result.AddRange(buckets[numBucket]);
                        }

                        // визуализация
                        int oldIndex;
                        int newIndex;
                        for (int i = 0; i < buckets[numBucket].Count; i++)
                        {
                            oldIndex = Array.IndexOf(Items.ToArray(), buckets[numBucket][i]);
                            newIndex = Array.IndexOf(result.ToArray(), buckets[numBucket][i]);
                            if (newIndex != oldIndex)
                            {
                                //int newIndex = count;
                                if (IsMSD)
                                {
                                    //newIndex += oldIndex * (index > 0 ? 1 : 0);
                                    //newIndex += prevIndex;
                                    //newIndex = newIndex < Items.Count ? newIndex : Items.Count - 1;
                                }
                                //Swap(count + (IsMSD ? (count + oldIndex * (index > 0 ? 1 : 0) < Items.Count ? count + oldIndex * (index > 0 ? 1 : 0) : Items.Count - 1) : 0), oldIndex);
                                Swap(newIndex, oldIndex);
                            }
                            count++;
                        }

                        if (count == items.Count)
                        {
                            break;
                        }
                        countBuckets++;
                    }
                    numBucket += (IsAscending ? 1 : -1);
                }
                if (!IsMSD)
                {
                    if (index + 1 < GetMaxLength(result))
                    {
                        result = GetFromBuckets(result, index + 1);
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
