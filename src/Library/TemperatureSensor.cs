using System.Threading;
using System;
using System.Collections.Generic;

namespace Observer
{
    public class TemperatureSensor : IObservado
    {
        
        public TemperatureSensor()
        {
            this.observers =  new List<IObservador>();
        }
        public List<IObservador> observers { get; private set; }
                
        public Temperature Current { get; private set; }

        public void Subscribe(IObservador observer)
        {
            if (! observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IObservador observer)
        {
            if (observers.Contains(observer))
            {
                this.observers.Remove(observer);
            }
        }

        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps = {14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m, 15.4m, 15.45m };
            // Store the previous temperature, so notification is only sent after at least .1 change.
            Nullable<Decimal> previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m ))
                    {
                        this.Current = new Temperature(temp.Value, DateTime.Now);
                        this.Notify();
                        previous = temp;
                        if (start)
                        {
                            start = false;
                        }
                    }
                }
            }
        }

        public void Notify()
        {
            foreach (IObservador observer in observers)
            {
                observer.Update(this.Current);
            }
        }
    }
}
