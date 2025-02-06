using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algsstructures.queue
{
    internal class PriorityQueue
    {
        // Элементы массива сортируются по значению ключа,
        // от максимумa (0) до минимума (maxSize-1)
        private int maxSize;
        private long[] queArray;
        private int nItems;
        //-------------------------------------------------------------
        public PriorityQueue(int s) // Конструктор
        {
            maxSize = s;
            queArray = new long[maxSize];
            nItems = 0;
        }
        //-------------------------------------------------------------
        public void insert(long item) // Вставка элемента
        {
            int j;
            if (nItems == 0) // Если очередь пуста,
                queArray[nItems++] = item; // вставляем в ячейку 0
            else // Если очередь содержит элементы
            {
                for (j = nItems - 1; j >= 0; j--) // Перебор в обратном направлении
                {
                    if (item > queArray[j]) // Если новый элемент больше,
                        queArray[j + 1] = queArray[j]; // сдвинуть вверх
                    else // Если меньше,
                        break; // сдвиг прекращается
                }
                queArray[j + 1] = item; // Вставка элемента
                nItems++;
            }
        } //
          //-------------------------------------------------------------
        public long remove() // Извлечение минимального элемента
        { return queArray[--nItems]; }
        //-------------------------------------------------------------
        public long peekMin() // Чтение минимального элемента
        { return queArray[nItems - 1]; }
        //-------------------------------------------------------------
        public bool isEmpty() // true, если очередь пуста
        { return (nItems == 0); }
        //-------------------------------------------------------------
        public bool isFull() // true, если очередь заполнена
        { return (nItems == maxSize); }
        //-------------------------------------------------------------
    }
}
