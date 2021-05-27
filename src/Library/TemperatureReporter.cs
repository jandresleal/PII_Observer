using System;

namespace Observer
{
    public class TemperatureReporter : IObservador
    {
        private bool first;
        private Temperature last;
        private IObservado provider;

        public void StartReporting(IObservado provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature value)
        {
            Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}");
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {value.Degrees - last.Degrees}° in " +
                    $"{value.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}