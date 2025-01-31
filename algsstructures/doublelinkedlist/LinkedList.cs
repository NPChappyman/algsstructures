using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algsstructures.doublelinkedlist
{
    internal class LinkedList<T>
    {
        public Link<T> First { get;  set; } // Ссылка на первый элемент списка
        public Link<T> Last { get;  set; }  // Ссылка на последний элемент списка

        // Конструктор
        public LinkedList()
        {
            First = null; // Список пока не содержит элементов
            Last = null;
        }

        public bool IsEmpty() // true, если список пуст
        {
            return First == null;
        }

        public void InsertFirst(T data) // Вставка элемента в начало списка
        {
            Link<T> newLink = new Link<T>(data); // Создание нового элемента
            if (IsEmpty()) // Если список не содержит элементов
                Last = newLink; // newLink <-- Last
            else
                First.Previous = newLink; // newLink <-- старое значение First
            newLink.Next = First; // newLink --> старое значение First
            First = newLink; // First --> newLink
        }

        public void InsertLast(T data) // Вставка элемента в конец списка
        {
            Link<T> newLink = new Link<T>(data); // Создание нового элемента
            if (IsEmpty()) // Если список не содержит элементов
                First = newLink; // First --> newLink
            else
            {
                Last.Next = newLink; // старое значение Last --> newLink
                newLink.Previous = Last; // старое значение Last <-- newLink
            }
            Last = newLink; // newLink <-- Last
        }

        public Link<T> DeleteFirst() // Удаление первого элемента
        {
            if (IsEmpty()) return null; // (предполагается, что список не пуст)
            Link<T> temp = First;
            if (First.Next == null) // Если только один элемент
                Last = null; // null <-- Last
            else
                First.Next.Previous = null; // null <-- старое значение Next
            First = First.Next; // First --> старое значение Next
            return temp;
        }

        public Link<T> DeleteLast() // Удаление последнего элемента
        {
            if (IsEmpty()) return null; // (предполагается, что список не пуст)
            Link<T> temp = Last;
            if (First.Next == null) // Если только один элемент
                First = null; // First --> null
            else
                Last.Previous.Next = null; // старое значение Previous --> null
            Last = Last.Previous; // старое значение Previous <-- Last
            return temp;
        }

        public bool InsertAfter(T key, T data) // Вставка data в позицию после key
        {
            Link<T> current = First; // От начала списка
            while (current != null && !current.Data.Equals(key)) // Пока не будет найдено совпадение
            {
                current = current.Next; // Переход к следующему элементу
            }
            if (current == null) return false; // Ключ не найден

            Link<T> newLink = new Link<T>(data); // Создание нового элемента
            if (current == Last) // Для последнего элемента списка
            {
                newLink.Next = null; // newLink --> null
                Last = newLink; // newLink <-- Last
            }
            else // Не последний элемент
            {
                newLink.Next = current.Next; // newLink --> старое значение Next
                current.Next.Previous = newLink; // старое значение Next <-- newLink
            }
            newLink.Previous = current; // старое значение current <-- newLink
            current.Next = newLink; // старое значение current --> newLink
            return true; // Ключ найден, вставка выполнена
        }

        public Link<T> DeleteKey(T key) // Удаление элемента с заданным ключом
        {
            Link<T> current = First; // От начала списка
            while (current != null && !current.Data.Equals(key)) // Пока не будет найдено совпадение
            {
                current = current.Next; // Переход к следующ
            }
            if (current == null) return null; // Ключ не найден

            // Если ключ найден, удаляем элемент
            if (current == First) // Удаляем первый элемент?
            {
                First = current.Next; // First --> старое значение Next
                if (First != null) // Если список не пуст после удаления
                {
                    First.Previous = null; // null <-- старое значение First
                }
            }
            else // Не первый элемент
            {
                current.Previous.Next = current.Next; // старое значение Previous --> старое значение Next
                if (current.Next != null) // Если не последний элемент
                {
                    current.Next.Previous = current.Previous; // старое значение Next <-- старое значение Previous
                }
                else // Если последний элемент
                {
                    Last = current.Previous; // старое значение Previous <-- Last
                }
            }
            return current; // Возвращение удаленного элемента
        }

        public void DisplayForward() // Отображение списка от первого к последнему
        {
            Console.Write("List (first-->last): ");
            Link<T> current = First; // От начала списка
            while (current != null) // Перемещение до конца списка
            {
                current.DisplayLink(); // Вывод данных
                current = current.Next; // Переход к следующему элементу
            }
            Console.WriteLine();
        }

        public void DisplayBackward() // Отображение списка от последнего к первому
        {
            Console.Write("List (last-->first): ");
            Link<T> current = Last; // От конца списка
            while (current != null) // Перемещение до начала списка
            {
                current.DisplayLink(); // Вывод данных
                current = current.Previous; // Переход к предыдущему элементу
            }
            Console.WriteLine();
        }
    }
}
