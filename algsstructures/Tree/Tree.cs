using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace algsstructures.Tree
{
    internal class Tree<T,K> where T : IComparable<T>
    {
        private Node<T,K> root; // Единственное поле данных
        public Node<T,K> getroot()
        {
            return root;
        }
        public void setroot(Node<T,K> w)
        {
            root = w;
        }
        public Node<T,K> find(T key) // Поиск узла с заданным ключом
        { // (предполагается, что дерево не пустое)
            Node<T,K> current = root; // Начать с корневого узла
            while (!current.key.Equals( key)) // Пока не найдено совпадение
            {
                if (key.CompareTo(current.key)<0) // Двигаться налево?
                    current = current.leftChild;
                else
                    current = current.rightChild; // Или направо?
                if (current == null) // Если потомка нет,
                    return null; // поиск завершился неудачей
            }
            return current; // Элемент найден
        }
        public void insert(T id)
        {
            Node<T,K> newNode = new Node<T,K>(); // Создание нового узла
            newNode.key = id;

            if (root == null) // Корневой узел не существует
                root = newNode;
            else // Корневой узел занят
            {
                Node<T,K> current = root; // Начать с корневого узла
                Node<T,K> parent;
                while (true) // (Внутренний выход из цикла)
                {
                    parent = current;
                    if (id.CompareTo( current.key)<0) // Двигаться налево?
                    {
                        current = current.leftChild;
                        if (current == null) // Если достигнут конец цепочки
                        { // вставить слева
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else // Или направо?
                    {
                        current = current.rightChild;
                        if (current == null) // Если достигнут конец цепочки,
                        { // вставить справа
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        // -------------------------------------------------------------
        public bool delete(T key)
        {
            Node<T,K> current = root;
            Node<T,K> parent = root;
            bool isLeftChild = true;
            while (current.key.Equals( key)) // Поиск узла
            {
                parent = current;
                if (key.CompareTo( current.key)<0) // Двигаться налево?
                {
                    isLeftChild = true;
                    current = current.leftChild;
                }
                else // Или направо?
                {
                    isLeftChild = false;
                    current = current.rightChild;
                }
                if (current == null) // Конец цепочки
                    return false; // Узел не найден
            }
            // Удаляемый узел найден
            // Если узел не имеет потомков, он просто удаляется.
            if (current.leftChild == null &&
                    current.rightChild == null)
            {
                if (current == root) // Если узел является корневым,
                    root = null; // дерево очищается
                else if (isLeftChild)
                    parent.leftChild = null; // Узел отсоединяется
                else // от родителя
                    parent.rightChild = null;
            }
            // Если нет правого потомка, узел заменяется левым поддеревом
            else if (current.rightChild == null)
                if (current == root)
                    root = current.leftChild;
                else if (isLeftChild)
                    parent.leftChild = current.leftChild;
                else
                    parent.rightChild = current.leftChild;
            // Если нет левого потомка, узел заменяется правым поддеревом
            else if (current.leftChild == null)
                if (current == root)
                    root = current.rightChild;
                else if (isLeftChild)
                    parent.leftChild = current.rightChild;
                else
                    parent.rightChild = current.rightChild;
            else // Два потомка, узел заменяется преемником
            {
                // Поиск преемника для удаляемого узла (current)
                Node<T,K> successor = getSuccessor(current);
                // Родитель current связывается с посредником
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.leftChild = successor;
                else
                    parent.rightChild = successor;
                // Преемник связывается с левым потомком current
                successor.leftChild = current.leftChild;
                return true;
            }
            return false;
        }


        // Метод возвращает узел со следующим значением после delNode<T,K>.
        // Для этого он сначала переходит к правому потомку, а затем
        // отслеживает цепочку левых потомков этого узла.
        private Node<T,K> getSuccessor(Node<T,K> delNode)
        {
            Node<T,K> successorParent = delNode;
            Node<T,K> successor = delNode;
            Node<T,K> current = delNode.rightChild; // Переход к правому потомку
            while (current != null) // Пока остаются левые потомки
            {
                successorParent = successor;
                successor = current;
                current = current.leftChild; // Переход к левому потомку
            }
            // Если преемник не является
            if (successor != delNode.rightChild) // правым потомком,
            { // создать связи между узлами
                successorParent.leftChild = successor.rightChild;
                successor.rightChild = delNode.rightChild;
            }
            return successor;
        }
        public void traverse(int traverseType)
        {
            switch (traverseType)
            {
                case 1:
                    Console.Write("\nPreorder traversal: ");
                    preOrder(root);
                    break;
                case 2:
                    Console.Write("\nInorder traversal: ");
                    inOrder(root);
                    break;
                case 3:
                    Console.Write("\nPostorder traversal: ");
                    postOrder(root);
                    break;
            }
            Console.WriteLine();
        }


        public void preOrder(Node<T,K> localRoot)
        {
            if (localRoot != null)
            {
                Console.Write(localRoot.key + " ");
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }
        public void postOrder(Node<T,K> localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
               Console.Write(localRoot.key + " ");
            }
        }

        public void inOrder(Node<T,K> localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                Console.Write(localRoot.key + " ");
                inOrder(localRoot.rightChild);
            }
        }

        public void displayTree()
        {
            Stack globalStack = new Stack();
            globalStack.Push(root);
            int nBlanks = 32;
            bool isRowEmpty = false;
            Console.WriteLine(
                    "......................................................");
            while (isRowEmpty == false)
            {
                Stack localStack = new Stack();
                isRowEmpty = true;
                for (int j = 0; j < nBlanks; j++)
                    Console.Write(' ');
                while (globalStack.Count != 0)
                {
                    Node<T,K> temp = (Node<T,K>)globalStack.Pop();
                    if (temp != null)
                    {
                        Console.Write(temp.key);
                        localStack.Push(temp.leftChild);
                        localStack.Push(temp.rightChild);
                        if (temp.leftChild != null ||
                                temp.rightChild != null)
                            isRowEmpty = false;
                    }
                    else
                    {
                        Console.Write("--");
                        localStack.Push(null);
                        localStack.Push(null);
                    }
                    for (int j = 0; j < nBlanks * 2 - 2; j++)
                        Console.Write(' ');
                }
                Console.WriteLine();
                nBlanks /= 2;
                while (localStack.Count != 0)
                    globalStack.Push(localStack.Pop());
            }
            Console.WriteLine(
                    "......................................................");
        }
        // -------------------------------------------------------------


        public Node<T,K> minimum() // Возвращает узел с минимальным ключом
        {
            Node<T,K> current;
            Node<T,K> last = null;
            current = root; // Обход начинается с корневого узла
            while (current != null) // и продолжается до низа
            {
                last = current; // Сохранение узла
                current = current.leftChild; // Переход к левому потомку
            }
            return last;
        }
    }
}
