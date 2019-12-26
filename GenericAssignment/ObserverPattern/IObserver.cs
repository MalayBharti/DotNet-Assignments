namespace ObserverPattern
{
    public interface IObserver<M>
    {
        M Update();
    }
}