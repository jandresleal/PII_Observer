using System;

namespace Observer
{
    public interface IObservado
    {
        void Subscribe(IObservador observer);
        void Unsubscribe(IObservador observer);
        void Notify();
    }
}