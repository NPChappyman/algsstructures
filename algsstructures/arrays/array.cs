using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algsstructures.arrays
{
    internal class array<T>
    {
        private T[] a; // Ссылка на массив a
        private int nElems; // Количество элементов в массиве
                            //-----------------------------------------------------------
        public array(int max) // Конструктор
        {
            a = new T[max]; // Создание массива
            nElems = 0; // Пока нет ни одного элемента
        }
        public int getSize()
        {
            return nElems;
        }
        public bool find(T searchKey)
        { // Поиск заданного значения
            int j = 0;
            for ( j=0 ; j < nElems; j++)
            // Для каждого элемента
                if (a[j].Equals(searchKey)) // Значение найдено?
                    break; // Да - выход из цикла
                if (j == nElems) // Достигнут последний элемент?
                    return false; // Да
                else
                    return true;
             // Нет
        }
        //-----------------------------------------------------------
        public void insert(T value) // Вставка элемента в массив
        {
            if (nElems + 1>a.Length)
            {
                T[] promo = new T[a.Length*2] ;
                for (int i=0 ; i < nElems; i++)
                {
                    promo[i] = a[i];
                }
                a = promo;
            }
            a[nElems] = value; // Собственно вставка
            nElems++; // Увеличение размера
        }
        //-----------------------------------------------------------
        public bool delete(T value)
        {
            int j = 0;
            for ( j = 0; j < nElems; j++) // Поиск заданного значения
                if (value.Equals(a[j]))
                    break;
            if (j == nElems) // Найти не удалось
                return false;
            else // Значение найдено
            {
                for (int k = j; k < nElems; k++) // Сдвиг последующих элементов
                    a[k] = a[k + 1];
                nElems--; // Уменьшение размера
                return true;
            }
        }
        //-----------------------------------------------------------
        public void display() // Вывод содержимого массива
        {
            for (int j = 0; j < nElems; j++) // Для каждого элемента
                Console.Write(a[j] + " "); // Вывод
            Console.WriteLine("");
        }
        public static int sfind<T>(T[] ar, T key, int lowercase, int upcase) where T : IComparable
        {
            int mid = (upcase + lowercase) / 2;
            if (ar[mid].Equals( key)) return mid;
            else
            {
                if (upcase < lowercase) return -1;
                if (ar[mid].CompareTo(key) > 0) return sfind(ar, key, lowercase, mid - 1);
                else return sfind(ar, key, mid + 1, upcase);
            }

        }
        public static int sortfind<T>(T[] ar, T y) where T : IComparable
        {
            return sfind(ar, y, 0, ar.Length - 1);
        }
        //-----------------------------------------------------------
    }
}
