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
            List<T> list = items.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                //if (Int32.TryParse())
                //{
                //    Items.Add();
                //}
                //else
                //{
                //    throw new ArrayTypeMismatchException();
                //    break;
                //}
            }
        }

        protected override void Sort()
        {
            List<T> busket = new List<T>();
            if (IsMSD)
            {

            }
            else
            {


            }

        }

    }
}
