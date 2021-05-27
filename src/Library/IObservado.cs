using System;
using System.Collections.Generic;

namespace Observer
{
    public interface IObservado
    {
        void Subscribe(IObservador observer);
        void Unsubscribe(IObservador observer);

        void Notify();

        List<IObservador> observers { get; }
    }
}