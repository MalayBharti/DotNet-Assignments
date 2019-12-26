namespace ObserverPattern
{
    public class Customer<T> : IObserver<string>
    {
        public T ObserverName { get; private set; }
        public Customer(T observerName)
        {
            ObserverName = observerName;
        }
        public string Update() => "New Update From Reatiler to : " + this.ObserverName;
    }
}