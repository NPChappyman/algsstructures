using algsstructures.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algsstructures.RedBlackTree
{
    internal class RedBlackTree<T, K> where T : IComparable<T>
    {
        public Node<T, K> root = Node<T, K>.nil;
        public K get(T key)
        {
            if (root == Node<T, K>.nil) return default(K);
            else
            {
                Node<T, K> currentNode = this.root;

                while (currentNode != Node<T, K>.nil)
                {
                    int cmp = key.CompareTo(currentNode.key); // Сравниваем ключи

                    if (cmp < 0)
                    {
                        currentNode = currentNode.left; // Идем влево
                    }
                    else if (cmp > 0)
                    {
                        currentNode = currentNode.right; // Идем вправо
                    }
                    else
                    {
                        return currentNode.value; // Ключ найден, возвращаем значение
                    }
                }
                return default(K); // Ключ не найден, возвращаем null
            }
        }
        public Node<T, K> find(T key) // Поиск узла с заданным ключом
        { // (предполагается, что дерево не пустое)
            Node<T, K> current = root; // Начать с корневого узла
            while (!current.key.Equals(key)) // Пока не найдено совпадение
            {
                if (key.CompareTo(current.key) < 0) // Двигаться налево?
                    current = current.left;
                else
                    current = current.right; // Или направо?
                if (current == null) // Если потомка нет,
                    return null; // поиск завершился неудачей
            }
            return current; // Элемент найден
        }

        public void insert(T key, K value)
        {
            Node<T, K> currentNode = this.root;
            Node<T, K> parrent = Node<T, K>.nil;
            while (nodeExists(currentNode))
            {
                parrent = currentNode;
                int cmp = key.CompareTo(currentNode.key);
                if (cmp < 0) currentNode = currentNode.left;
                else currentNode = currentNode.right;
            }
            Node<T, K> newNode = new Node<T, K>();
            createNode(newNode, key, value);
            newNode.parent = parrent;
            if (parrent == Node<T, K>.nil) root = newNode;
            else if (key.CompareTo(parrent.key) < 0) parrent.left = newNode;
            else parrent.right = newNode;
            balanceTree(newNode);

        }
        void balanceTree(Node<T, K> node)
        {

            Node<T, K> uncle;
            while (node.parent.color == Color.RED)
            {
                if (node.parent == node.parent.parent.left)
                {
                    uncle = node.parent.parent.right;
                    if (uncle.color == Color.RED)
                    {
                        uncle.color = Color.BLACK;
                        node.parent.parent.color = Color.RED;
                        node.parent.color = Color.BLACK;
                        node = node.parent.parent;

                    }
                    else
                    {

                        if (node == node.parent.right)
                        {
                            node = node.parent;
                            rotateLeft(node);
                        }
                        node.parent.color = Color.BLACK;
                        node.parent.parent.color = Color.RED;
                        rotateRight(node.parent.parent);
                    }
                }
                else
                {
                    uncle = node.parent.parent.left;
                    if (uncle.color == Color.RED)
                    {
                        uncle.color = Color.BLACK;
                        node.parent.parent.color = Color.RED;
                        node.parent.color = Color.BLACK;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.left)
                        {
                            node = node.parent;
                            rotateRight(node);
                        }
                        node.parent.color = Color.BLACK;
                        node.parent.parent.color = Color.RED;
                        rotateLeft(node.parent.parent);
                    }
                }
            }
            root.color = Color.BLACK;


        }
        // this function performs left rotation
        Node<T, K> rotateLeft(Node<T, K> node)
        {
            Node<T, K> x = node.right;
            node.right = x.left; // Изменение ссылки на левое поддерево x
            if (x.left != Node<T, K>.nil)
            {
                x.left.parent = node; // Обновляем родителя
            }
            x.parent = node.parent; // Обновляем родителя x
            if (node.parent == Node<T, K>.nil)
            {
                root = x; // Если node был корнем, обновляем корень
            }
            else if (node == node.parent.left)
            {
                node.parent.left = x; // Обновляем ссылку родителя
            }
            else
            {
                node.parent.right = x;
            }
            x.left = node; // Вращение
            node.parent = x; // Обновляем родителя
            return x;
        }

        Node<T, K> rotateRight(Node<T, K> node)
        {
            Node<T, K> x = node.left;
            node.left = x.right; // Изменение ссылки на правое поддерево x
            if (x.right != Node<T, K>.nil)
            {
                x.right.parent = node; // Обновляем родителя
            }
            x.parent = node.parent; // Обновляем родителя x
            if (node.parent == Node<T, K>.nil)
            {
                root = x; // Если node был корнем, обновляем корень
            }
            else if (node == node.parent.right)
            {
                node.parent.right = x; // Обновляем ссылку родителя
            }
            else
            {
                node.parent.left = x;
            }
            x.right = node; // Вращение
            node.parent = x; // Обновляем родителя
            return x;
        }
        bool nodeExists(Node<T, K> node)
        {
            return node != Node<T, K>.nil;
        }
        void createNode(Node<T, K> node, T key, K value)
        {
            node.parent = Node<T, K>.nil;
            node.left = Node<T, K>.nil;
            node.right = Node<T, K>.nil;
            node.key = key;
            node.value = value;
            node.color = Color.RED;
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
                    Node<T, K> temp = (Node<T, K>)globalStack.Pop();
                    if (temp != null && temp != Node<T, K>.nil)
                    {
                        Console.Write(temp.key);
                        localStack.Push(temp.left);
                        localStack.Push(temp.right);
                        if (temp.left != null ||
                                temp.right != null)
                            isRowEmpty = false;
                    }
                    else
                    {
                        Console.Write("--");
                        localStack.Push(null);
                        localStack.Push(null);
                    }
                    for (int j = 0; j < nBlanks * 2 - 2; j++)
                        Console.Write(" ");
                }
                Console.WriteLine();
                nBlanks /= 2;
                while (localStack.Count != 0)
                    globalStack.Push(localStack.Pop());
            }
            Console.WriteLine(
                    "......................................................");
        }

        private void preOrderHelper(Node<T, K> node)
        {
            if (node != Node<T, K>.nil)
            {
                Console.Write(node.key + " ");
                preOrderHelper(node.left);
                preOrderHelper(node.right);
            }
        }
        public void preorder()
        {
            preOrderHelper(this.root);
        }

        // Inorder traversal helper function
        private void inOrderHelper(Node<T, K> node)
        {
            if (node != Node<T, K>.nil)
            {
                inOrderHelper(node.left);
                Console.Write(node.key + " ");
                inOrderHelper(node.right);
            }
        }

        // Function to start inorder traversal
        public void inorder()
        {
            inOrderHelper(this.root);
        }

        // Postorder traversal helper function
        private void postOrderHelper(Node<T, K> node)
        {
            if (node != Node<T, K>.nil)
            {
                postOrderHelper(node.left);
                postOrderHelper(node.right);
                Console.Write(node.key + " ");
            }
        }

        // Function to start postorder traversal
        public void postorder()
        {
            postOrderHelper(this.root);
        }
        private Node<T, K> getMin(Node<T, K> node) // Возвращает узел с минимальным ключом
        {
            if (node == Node<T, K>.nil) return Node<T, K>.nil; // Проверяем, что узел не nil

            while (node.left != Node<T, K>.nil) // Ищем самый левый узел
            {
                node = node.left;
            }
            return node;
        }
        public void remove(T key)
        {
            Node<T, K> nodeToDelete = find(key);
            if (nodeToDelete == null) { Console.WriteLine(" There is no element with key " + key); return; }
            if (nodeToDelete == Node<T, K>.nil) // Проверяем, найден ли узел
            {
                throw new InvalidOperationException($"Node with key {key} not found.");
            }

            Color removedNodeColor = nodeToDelete.color;
            Node<T, K> child;

            if (getChildrenCount(nodeToDelete) < 2) // Если у узла меньше двух детей
            {
                child = getChildOrMock(nodeToDelete);
                transplantNode(nodeToDelete, child);
            }
            else // Если у узла два ребенка
            {
                Node<T, K> minNode = getMin(nodeToDelete.right);
                if (minNode == Node<T, K>.nil) // Проверяем, что minNode не nil
                {
                    throw new InvalidOperationException("Minimum node cannot be null.");
                }

                nodeToDelete.key = minNode.key; // Копируем ключ и значение
                nodeToDelete.value = minNode.value;
                removedNodeColor = minNode.color;
                child = getChildOrMock(minNode);
                transplantNode(minNode, child); // Удаляем minNode
            }

            if (removedNodeColor == Color.BLACK) // Если удаляемый узел был черным
            {
                fixRulesAfterRemoval(child);
            }
        }

        private int getChildrenCount(Node<T, K> node)
        {
            int count = 0;
            if (nodeExists(node.left)) count += 1;
            if (nodeExists(node.right)) count += 1;
            return count;
        }
        private Node<T, K> getChildOrMock(Node<T, K> node)
        {
            if (node.left != Node<T, K>.nil) return node.left; // Возвращаем левого ребенка, если он существует
            return node.right; // Иначе возвращаем правого ребенка
        }
        private void transplantNode(Node<T, K> toNode, Node<T, K> fromNode)
        {
            if (toNode == null)
            {
                throw new ArgumentNullException(nameof(toNode), "toNode cannot be null.");
            }

            if (fromNode == null)
            {
                // Если fromNode равен null, мы просто удаляем toNode
                if (toNode == this.root)
                {
                    this.root = null; // Если toNode - корень, устанавливаем корень в null
                }
                else if (toNode == toNode.parent.left)
                {
                    toNode.parent.left = null; // Удаляем узел из левого поддерева
                }
                else
                {
                    toNode.parent.right = null; // Удаляем узел из правого поддерева
                }
                return;
            }

            // Если toNode - корень, обновляем корень
            if (toNode == this.root)
            {
                this.root = fromNode;
            }
            else if (toNode == toNode.parent.left)
            {
                toNode.parent.left = fromNode;
            }
            else
            {
                toNode.parent.right = fromNode;
            }

            fromNode.parent = toNode.parent;
        }

        private void fixRulesAfterRemoval(Node<T, K> node)
        {
            while (node != this.root && node.color == Color.BLACK)
            {
                Node<T, K> brother;
                if (node == node.parent.left)
                {
                    brother = node.parent.right;
                    if (brother.color == Color.RED)
                    {
                        brother.color = Color.BLACK;
                        node.parent.color = Color.RED;
                        rotateLeft(node.parent);
                        brother = node.parent.right;
                    }
                    if (brother.left.color == Color.BLACK && brother.right.color == Color.BLACK)
                    {
                        brother.color = Color.RED;
                        node = node.parent;
                    }
                    else
                    {
                        if (brother.right.color == Color.BLACK)
                        {
                            brother.left.color = Color.BLACK;
                            brother.color = Color.RED;
                            rotateRight(brother);
                            brother = node.parent.right;
                        }
                        brother.color = node.parent.color;
                        node.parent.color = Color.BLACK;
                        brother.right.color = Color.BLACK;
                        rotateLeft(node.parent);
                        node = this.root;
                    }
                }
                else
                {
                    brother = node.parent.left;
                    if (brother.color == Color.RED)
                    {
                        brother.color = Color.BLACK;
                        node.parent.color = Color.RED;
                        rotateRight(node.parent);
                        brother = node.parent.left;
                    }
                    if (brother.left.color == Color.BLACK && brother.right.color == Color.BLACK)
                    {
                        rotateRight(node.parent);
                        brother = node.parent.left;
                    }
                    else
                    {
                        if (brother.left.color == Color.BLACK)
                        {
                            brother.right.color = Color.BLACK;
                            brother.color = Color.RED;
                            rotateLeft(brother);
                            brother = node.parent.left;
                        }
                        brother.color = node.parent.color;
                        node.parent.color = Color.BLACK;
                        brother.left.color = Color.BLACK;
                        rotateRight(node.parent);
                        node = this.root;
                    }
                }
            }
            node.color = Color.BLACK;
        }
        private int getChildrenOrMock(Node<T, K> node)
        {
            if (node == null) return 0;

            int count = 0;
            if (node.left != null) count++;
            if (node.right != null) count++;
            return count;
        }
    }
}
