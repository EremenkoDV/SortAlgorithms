using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Node<T>
        where T : IComparable
    {
        public T Data { get; set; }

        public int Index { get; private set; }

        public Node<T> Right { get; set; }

        public Node<T> Left { get; set; }

        public Node() { }

        public Node(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Node<T> current = Root;
            //int parentIndex = (int)(index - 1) / 2;
            //int leftIndex = 2 * index + 1;
            //int rightIndex2 = 2 * index + 2;

                for (int i = 0; i <= Index; i++)
                {
                    yield return Data;
                }

        }


    }

}
