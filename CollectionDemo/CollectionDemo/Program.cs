using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList list = new SortedList();
            list.Add(4, 10);
            list.Add(2, 2);
            list.Add(5, 5);
            list.Add(1, 8);
            list.Add(3, 43);
            list.Add(6, "Malay");

            Console.WriteLine(list.Contains(6));

            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine("Key {0} with value {1}", item.Key, item.Value);
            }
        }
    }
}