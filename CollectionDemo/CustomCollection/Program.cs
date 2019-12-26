using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCollection list = new TestCollection();
            Console.WriteLine(list.Count);
            Console.WriteLine(list.GetType());
        }
    }
}
