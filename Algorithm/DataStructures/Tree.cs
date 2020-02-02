using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Tree<T>
        where T : IComparable
    {

        public Node<T> Root { get; private set; }

        public Tree() { }

        public Tree(T data)
        {
            Root = new Node<T>(data);
        }

        public Tree(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }

        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node<T> current = Root;
                while (current != null)
                {
                    //if (current.Data.CompareTo(data) > 0)
                    if (current.CompareTo(node) > 0) // налево идут элементы меньше текущего
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
            }
        }

        public bool Remove(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> previous = null;
            Node<T> current = Root;
            while (current != null)
            {
                //if (current.Data.CompareTo(data) > 0)
                if (current.CompareTo(node) > 0) // налево идут элементы меньше текущего
                {
                    if (current.Left != null)
                    {
                        previous = current;
                        current = current.Left;
                    }
                }
                else if (current.CompareTo(node) == 0) // элемент равен текущего - удаление
                {

                    List<T> prefix = PrefixIteration(current);
                    prefix.RemoveAt(0);

                    if (previous.CompareTo(node) > 0) // элемент равен текущего - удаление
                        previous.Left = null;
                    else
                        previous.Right = null;

                    foreach (T switchData in prefix)
                        Add(switchData);

                    return true;
                }
                else // направо идут элементы больше текущего
                {
                    if (current.Right != null)
                    {
                        previous = current;
                        current = current.Right;
                    }
                }
            }
            return false;
        }

        public List<T> PrefixIteration(Node<T> node = null)
        {
            List<T> result = new List<T>();

            if (node == null)
                node = Root;

            result.Add(node.Data);

            if (node.Left != null)
            {
                result.AddRange(PrefixIteration(node.Left));
                //foreach (T data in PrefixIteration(node.Left))
                //{
                //    result.Add(data);
                //}
            }
            if (node.Right != null)
            {
                result.AddRange(PrefixIteration(node.Right));
                //foreach (T data in PrefixIteration(node.Right))
                //{
                //    result.Add(data);
                //}
            }

            return result;
        }

        public List<T> InfixIteration(Node<T> node = null)
        {
            List<T> result = new List<T>();

            if (node == null)
                node = Root;

            if (node.Left != null)
            {
                result.AddRange(InfixIteration(node.Left));
                //foreach (T data in InfixIteration(node.Left))
                //{
                //    result.Add(data);
                //}
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

        public List<T> PostfixIteration(Node<T> node = null)
        {
            List<T> result = new List<T>();

            if (node == null)
                node = Root;

            if (node.Left != null)
            {
                result.AddRange(PostfixIteration(node.Left));
                //foreach (T data in PostfixIteration(node.Left))
                //{
                //    result.Add(data);
                //}
            }

            if (node.Right != null)
            {
                result.AddRange(PostfixIteration(node.Right));
                //foreach (T data in PostfixIteration(node.Right))
                //{
                //    result.Add(data);
                //}
            }

            result.Add(node.Data);

            return result;
        }


    }
}
