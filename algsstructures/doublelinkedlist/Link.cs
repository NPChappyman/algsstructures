using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algsstructures.doublelinkedlist
{
    internal class Link<T>
    {
        public T Data { get; set; }
        public Link<T> Next { get; set; }
        public Link<T> Previous { get; set; }

        public Link(T data)
        {
            Data = data;
        }

        public void DisplayLink()
        {
            Console.Write($"{Data} ");
        }
    }
}
