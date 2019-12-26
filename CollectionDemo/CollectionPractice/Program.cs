using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionPractice
{
    
    class Program
    {
        public static void Print(ArrayList list)
        {
           
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            ArrayList NewList = new ArrayList();
            NewList.Add(7);
            NewList.Add(56);
            NewList.Add(54);
            NewList.Add(32);
            NewList.Add(7);
            NewList.Add("Seven");
            NewList.Add("Zero");
            NewList.Add(true);

            Console.WriteLine("Elements in the List are: ");
            Print(NewList);

            Console.WriteLine("Elements Count in the List are: ");
            Console.WriteLine(NewList.Count);

            NewList.Insert(6, "C#");

            Console.WriteLine("Elements in the List are: ");
            Print(NewList);
        }
    }
}
