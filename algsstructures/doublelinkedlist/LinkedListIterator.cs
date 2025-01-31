using algsstructures.doublelinkedlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algsstructures.LinkedList
{
    internal class LinkedListIterator<T>
    {
        private Link<T> current;

        private algsstructures.doublelinkedlist.LinkedList<T> ourList;

        public LinkedListIterator(algsstructures.doublelinkedlist.LinkedList<T> p)
        {
            ourList = p;
            reset();
        }

        public bool atEnd() // true, если текущим является
        { return (current.Next == null); } // последний элемент

        public void reset()
        {
            current = ourList.First;

        }

        public void nextLink() 
        {
            if (current == null) return;
            if (current.Next != null)
            {
                current = current.Next;
            }
            else
            {
                current = ourList.First;
            }
        }
        public void previousLink() 
        {
            if (current.Previous != null)
            {
                current = current.Previous;
            }
            else
            {
                current = ourList.Last;
            }
           
        }
        //--------------------------------------------------------------
        public Link<T> getCurrent() // Получение текущего элемента
        { return current; }

        public void insertAfter(T dd) 
        { 
            Link<T> newLink = new Link<T>(dd);
            if (ourList.IsEmpty()) 
            {
                ourList.First=(newLink);
                current = newLink;

            }
            else if (current.Next == null)
            {
                ourList.Last = newLink;
                current.Next = newLink;
                newLink.Previous = current;
                nextLink();

            }
            else 
            {
                newLink.Next = current.Next;
                current.Next.Previous = newLink;
                current.Next = newLink;
                newLink.Previous = current;
                nextLink(); 
            }
        }
        //--------------------------------------------------------------
        public void insertBefore(T dd) // Вставка перед
        { // текущим элементом
            Link<T> newLink = new Link<T>(dd);
            if (current.Previous == null) // В начале списка
            { // (или пустой список)
                newLink.Next = ourList.First;
                ourList.First=(newLink);
                reset();
            }
            else // Не в начале списка
            {
                newLink.Next = current;
                newLink.Previous = current.Previous;
                current.Previous.Next = newLink;
                current.Previous = newLink;
                current = newLink;
            }
        }
        //--------------------------------------------------------------
        public void deleteCurrent() // Удаление текущего элемента
        {
            if (current == null) return ;
            T value = current.Data;
            if (current.Previous == null) // Если в начале списка
            {
                if (current.Next == null)
                {
                    ourList.First = null;
                    ourList.Last = null;
                    ourList.First=(null);
                    current = null;
                }
                else
                {
                    ourList.First=(current.Next);
                    current.Next.Previous = null;
                    reset();
                }
            }

            else // Не в начале списка
            {
                current.Previous.Next = current.Next;
                if (!atEnd())
                {
                    current.Next.Previous = current.Previous.Next;
                    current = current.Next;
                }
                else
                {
                    ourList.Last = current.Previous;

                    reset();
                }


            }
            
        }
    }
}
