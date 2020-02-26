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
            Items = GetHalfList(Items);
        }

        private List<T> GetHalfList(List<T> items, int startIndex = 0)
        {
            List<T> leftOfPairItems = new List<T>();
            List<T> rightOfPairItems = new List<T>();
            List<T> sortedItems = new List<T>();

            if (items.Count > 2)
            {
                leftOfPairItems = GetHalfList(items.GetRange(0, items.Count / 2), startIndex);
                rightOfPairItems = GetHalfList(items.GetRange(items.Count / 2, items.Count - items.Count / 2), startIndex + items.Count / 2);
            }
            else
            {
                leftOfPairItems.Add(items[0]);
                if (items.Count == 2)
                {
                    rightOfPairItems.Add(items[1]);
                }
            }
            sortedItems = GetMergedList(leftOfPairItems, rightOfPairItems, startIndex);
            return sortedItems;
        }

        private List<T> GetMergedList(List<T> leftOfPairItems, List<T> rightOfPairItems, int startIndex)
        {
            List<T> mergedItems = new List<T>();
            int i = 0;
            int j = 0;
            do
            {
                if (i >= leftOfPairItems.Count && j < rightOfPairItems.Count)
                {
                    mergedItems.AddRange(rightOfPairItems.GetRange(j, rightOfPairItems.Count - j));
                    break;
                }
                else if (j >= rightOfPairItems.Count && i < leftOfPairItems.Count)
                {
                    mergedItems.AddRange(leftOfPairItems.GetRange(i, leftOfPairItems.Count - i));
                    break;
                }
                else if (i < leftOfPairItems.Count && j < rightOfPairItems.Count)
                {
                    int leftIndex = Array.IndexOf(Items.ToArray(), leftOfPairItems[i], startIndex, leftOfPairItems.Count + rightOfPairItems.Count);
                    int rightIndex = Array.IndexOf(Items.ToArray(), rightOfPairItems[j], startIndex, leftOfPairItems.Count + rightOfPairItems.Count);

                    if (Compare(leftIndex, rightIndex) == (IsAscending ? -1 : 1))
                    {
                        mergedItems.Add(leftOfPairItems[i]);
                        i++;
                    }
                    else
                    {
                        mergedItems.Add(rightOfPairItems[j]);
                        InsertAt(startIndex + mergedItems.Count - 1, rightIndex);
                        j++;
                    }
                }
                else
                {
                    break;
                }

            } while (mergedItems.Count < leftOfPairItems.Count + rightOfPairItems.Count);
            return mergedItems;
        }

    }
}
