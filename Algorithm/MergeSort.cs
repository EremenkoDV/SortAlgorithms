using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class GetHalfList<T> : AlgorithmBase<T>
        where T : IComparable
    {

        private List<T> leftPairItems = new List<T>();

        private List<T> rightPairItems = new List<T>();

        public GetHalfList() { }

        public GetHalfList(IEnumerable<T> items) : base(items)
        {

        }

        protected override void Sort()
        {
            base.Sort();
        }

        private void SetHalfList(List<T> items = null)
        {
            if (items == null)
            {
                items = Items;
            }
            if (items.Count > 2)
            {
                //leftPairItems.AddRange(items.GetRange(0, items.Count / 2));
                //rightPairItems.AddRange(items.GetRange(items.Count / 2 + 1, items.Count - items.Count / 2));
                leftPairItems = items.GetRange(0, items.Count / 2);
                rightPairItems = items.GetRange(items.Count / 2 + 1, items.Count - items.Count / 2);
                SetHalfList(leftPairItems);
                //return GetHalfList(items.GetRange(0, items.Count / 2));
            }
            else
            {
                //leftPairItems.AddRange(items.GetRange(0, items.Count / 2));
                rightPairItems = new List<T>(items[0]);
                //return items;
            }

            Merge();
        }

        private void Merge()
        {
            for (int i = 0; i < leftPairItems.Count; i++)
            {
                for (int j = 0; j < rightPairItems.Count; j++)
                {
                    if (Compare(i, j) == (IsAscending ? 1 : -1))
                    {
                        Swap(i, j);
                    }
                }

            }
        }

    }
}
