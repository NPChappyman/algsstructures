using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algsstructures.RedBlackTree
{
    enum Color
    {
        RED, BLACK
    }
    internal class Node<T,K> where T: IComparable<T>
    {
        
        public T key;
        public K value;
        public Node<T, K> left = null;
        public Node<T, K> right = null;
        public Color color = Color.BLACK;
        public Node<T, K> parent = null;
        public static Node<T, K> nil = new Node<T, K>();
        public Node(T key, K value)
        {
            this.key = key;
            this.value = value;
            this.color = Color.RED;
            this.left = nil;
            this.right = nil;
            this.parent = nil;

        }
        public Node()
        {

        }
    }
}

