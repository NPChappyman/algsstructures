using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algsstructures.Tree
{
    internal class Node<T,K> where T: IComparable<T>
    {
        public T key ; // Данные, используемые в качестве ключа
        public K iData;
        public Node(T k, K d)
        {
            key = k;
            iData = d;
        }
        public Node()
        {

        }
        public Node<T,K> leftChild; // Левый потомок узла
        public Node<T,K> rightChild; // Правый потомок узла
        public void displayNode()
        {
            Console.WriteLine(iData);
        }
    }
}
