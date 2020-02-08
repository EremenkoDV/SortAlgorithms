using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Tree<T> : AlgorithmBase<T>
        where T : IComparable
    {

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public Tree() { }

        public Tree(T data)
        {
            Count = 1;
            Root = new Node<T>(data);
            Root.Index = 1;
        }

        public Tree(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public override void AddRange(IEnumerable<T> items)
        {
            List<T> list = items.ToList();
            foreach (T item in list)
            {
                Items.Add(item);
                Add(item);
            }

        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Index = Count;
            if (Root == null)
            {
                Root = node;
                Count = 1;
            }
            else
            {
                Node<T> current = Root;
                while (current != null)
                {
                    //if (current.Data.CompareTo(data) > 0)
                    if (Compare(current.Index, node.Index) == (IsAscending ? 1 : -1)) // налево идут элементы меньше текущего
                    {
                        if (current.Left != null)
                            current = current.Left;
                        else
                        {
                            current.Left = node;
                            Count++;
                            return;
                        }
                    }
                    else // направо идут элементы больше или равно текущего
                    {
                        if (current.Right != null)
                            current = current.Right;
                        else
                        {
                            current.Right = node;
                            Count++;
                            return;
                        }
                    }
                }
            }
        }

        public List<T> InfixIteration(Node<T> node = null)
        {
            List<T> result = new List<T>();

            if (node == null)
                node = Root;

            if (node.Left != null)
            {
                result.AddRange(InfixIteration(node.Left));
            }

            result.Add(node.Data);

            if (node.Right != null)
            {
                result.AddRange(InfixIteration(node.Right));
            }

            return result;
        }

        public List<int> InfixIndexes(Node<T> node = null)
        {
            List<int> result = new List<int>();

            if (node == null)
                node = Root;

            if (node.Left != null)
            {
                result.AddRange(InfixIndexes(node.Left));
            }

            result.Add(node.Index);

            if (node.Right != null)
            {
                result.AddRange(InfixIndexes(node.Right));
            }

            return result;
        }

        protected override void Sort()
        {
            int index;
            List<int> indexes = InfixIndexes();
            List<int> newIndexes = new List<int>();
            for (int i = 0; i < indexes.Count; i++)
            {
                if (indexes.Any(e => e == i))
                {
                    newIndexes.Add(indexes.IndexOf(i));
                }
            }
            for (int i = 0; i < newIndexes.Count - 1; i++)
            {
                index = newIndexes.IndexOf(i);

                if (i != index)
                {
                    Swap(i, index);

                    int temp = newIndexes[index];
                    newIndexes[index] = newIndexes[i];
                    newIndexes[i] = temp;
                }

            }
        }

        //public T GetNext(int index, Node<T> node = null)
        //{
        //    T result;
        //    if (node == null)
        //    {
        //        node = Root;
        //    }
        //    Node<T> current = node;
        //    while (current != null)
        //    {
        //        if (index == current.Index)
        //        {
        //            result = current.Data;
        //        }
        //        if (current.Left != null) // налево идут элементы меньше текущего
        //        {
        //            result = GetNext(index, current.Left);
        //            //current = current.Left;
        //        }
        //        if (current.Right != null) // направо идут элементы больше или равно текущего
        //        {

        //            result = GetNext(index, current.Right);
        //            //current = current.Right;
        //        }
        //        break;
        //    }
        //    if (is result)
        //    return result;
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        yield return GetNext(i);
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        yield return GetNext(i);
        //    }
        //}
    }
}
