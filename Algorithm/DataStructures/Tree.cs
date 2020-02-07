using System;
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
                    if (current.Data.CompareTo(data) > 0)
                    //if (Compare(current.Data, node.Data) > 0) // налево идут элементы меньше текущего
                    {
                        if (current.Left != null)
                            current = current.Left;
                        else
                        {
                            current.Left = node;
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
                            return;
                        }
                    }
                }
                Count++;
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
                //foreach (T data in InfixIteration(node.Right))
                //{
                //    result.Add(data);
                //}
            }

            return result;
        }

        protected override void Sort()
        {
            Items = InfixIteration();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Node<T> current = Root;
            //int parentIndex = (int)(index - 1) / 2;
            //int leftIndex = 2 * index + 1;
            //int rightIndex2 = 2 * index + 2;

            if (node == null)
                node = Root;

            if (node.Left != null)
            {
                foreach (T data in GetEnumerator(node.Left))
                {
                    yield return node.Data;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (T data in GetEnumerator(node.Right))
                {
                    yield return node.Data;
                }
            }

        }

    }
}
