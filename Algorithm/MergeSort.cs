using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class MergeSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public MergeSort() { }

        public MergeSort(IEnumerable<T> items) : base(items)
        {

        }

        protected override void Sort()
        {
            Items = GetSortedList(Items);
        }

        private List<T> GetSortedList(List<T> items, int startIndex = 0)
        {

            if (items.Count == 1)
            {
                return items;
            }

            int halfCount = items.Count / 2;
            List<T> leftHalfItems = items.GetRange(0, halfCount);
            List<T> rightHalfItems = items.GetRange(halfCount, items.Count - halfCount);
            //List<T> leftHalfItems = items.Take(halfCount).ToList();
            //List<T> rightHalfItems = items.Skip(halfCount).ToList();

            return GetMergedList(GetSortedList(leftHalfItems, startIndex), GetSortedList(rightHalfItems, startIndex + halfCount), startIndex);
        }

        private List<T> GetMergedList(List<T> leftHalfItems, List<T> rightHalfItems, int startIndex)
        {
            List<T> mergedItems = new List<T>();
            int i = 0;
            int j = 0;
            do
            {
                if (i >= leftHalfItems.Count && j < rightHalfItems.Count)
                {
                    mergedItems.AddRange(rightHalfItems.GetRange(j, rightHalfItems.Count - j));
                    break;
                }
                else if (j >= rightHalfItems.Count && i < leftHalfItems.Count)
                {
                    mergedItems.AddRange(leftHalfItems.GetRange(i, leftHalfItems.Count - i));
                    break;
                }
                else if (i < leftHalfItems.Count && j < rightHalfItems.Count)
                {
                    int leftIndex = Array.IndexOf(Items.ToArray(), leftHalfItems[i], startIndex, leftHalfItems.Count + rightHalfItems.Count);
                    int rightIndex = Array.IndexOf(Items.ToArray(), rightHalfItems[j], startIndex, leftHalfItems.Count + rightHalfItems.Count);

                    if (Compare(rightIndex, leftIndex) == (IsAscending ? 1 : -1))
                    {
                        mergedItems.Add(leftHalfItems[i]);
                        i++;
                    }
                    else
                    {
                        mergedItems.Add(rightHalfItems[j]);
                        InsertAt(startIndex + mergedItems.Count - 1, rightIndex);
                        j++;
                    }
                }
                else
                {
                    break;
                }

            } while (mergedItems.Count < leftHalfItems.Count + rightHalfItems.Count);
            return mergedItems;
        }

    }
}
