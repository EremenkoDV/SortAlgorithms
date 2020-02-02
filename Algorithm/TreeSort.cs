using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class TreeSort<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public TreeSort() { }

        public TreeSort(IEnumerable<T> items) : base(items) { }
        
        protected override void Sort()
        {
            // Загрузка в Tree
            DataStructures.Tree<T> tree = new DataStructures.Tree<T>(Items);
            //for (int i = 0; i < Items.Count; i++)
            //{
            //    tree.Add(Items[i]);
            //}

            // сортировка
            Items = tree.InfixIteration();
        }

    }
}
