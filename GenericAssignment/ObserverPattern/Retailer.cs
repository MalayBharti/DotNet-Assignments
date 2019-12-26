using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class Retailer<T> : ISubject<string>
    {
        private List<Customer<string>> observers = new List<Customer<string>>();

        private int _int;
        public void Subscribe(Customer<string> observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Customer<string> observer)
        {
            observers.Remove(observer);
        }
        public int Products
        {
            get
            {
                return _int;
            }
            set
            {
                if (value > _int)
                    Notify();
                _int = value;
            }
        }
        public void Notify()
        {
            observers.ForEach(x => Console.WriteLine(x.Update()));
        }
    }
}