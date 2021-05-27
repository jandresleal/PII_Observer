namespace Observer
{
    public interface IObservable
    {
        void Subscribe(IObservador observer);
        void Unsubscribe(IObservador observer);
        void Notify();
    }
}