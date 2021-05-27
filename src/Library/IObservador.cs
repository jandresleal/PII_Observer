using System;

namespace Observer
{
    public interface IObservador
    {
        void Update(Temperature value);
    }
}