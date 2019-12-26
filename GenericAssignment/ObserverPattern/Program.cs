using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Retailer<int> subject = new Retailer<int>();

            Customer<string> observer1 = new Customer<string>("Customer 1");
            subject.Subscribe(observer1);

            subject.Subscribe(new Customer<string>("Customer 2"));
            subject.Products++;

            subject.Unsubscribe(observer1);

            subject.Subscribe(new Customer<string>("Customer 3"));
            subject.Products++;

            Console.ReadLine();
        }
    }
}