using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Node<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }

        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }

        public Node() { }

        public Node(T data)
        {
            Data = data;
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item.Data);
            }
            else
            {
                throw new Exception("Не совпадение типов!");
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

}
