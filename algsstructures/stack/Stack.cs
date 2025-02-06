using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algsstructures.stack
{
    internal class stack<T>
    {
        private int maxSize; // Размер массива
        private T[] stackArray;
        private int top; // Вершина стека
                         //------------------------
        public stack(int s) // Конструктор
        {
            maxSize = s; // Определение размера стека
            stackArray = new T[maxSize]; // Создание массива
            top = -1; // Пока нет ни одного элемента
        }
        //--------------------------------------------------------------
        public void push(T j) // Размещение элемента на вершине стека
        {
            stackArray[++top] = j; // Увеличение top, вставка элемента
        }
        //--------------------------------------------------------------
        public T pop() // Извлечение элемента с вершины стека
        {
            return stackArray[top--]; // Извлечение элемента, уменьшение top
        }

        //--------------------------------------------------------------
        public T peek() // Чтение элемента с вершины стека
        {
            return stackArray[top];
        }
        //--------------------------------------------------------------
        public bool isEmpty() // True, если стек пуст
        {
            return (top == -1);
        }
        //--------------------------------------------------------------
        public bool isFull() // True, если стек полон
        {
            return (top == maxSize - 1);
        }
        //--------------------------------------------------------------
        // Конец класса StackX
        ////////////////////////////////////////////////////////////////
    }
}
