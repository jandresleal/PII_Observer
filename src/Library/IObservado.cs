using System;
using System.Collections;

namespace Observer
{
    public interface IObservado
    {
        void Subscribe(IObservador observer);
        void Unsubscribe(IObservador observer);
        //void Notify();
        //ArrayList List<IObservador>();
    }
}