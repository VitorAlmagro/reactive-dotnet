using System;
using System.Collections.Generic;

namespace ReactiveExample
{
    public class Observable : ISubject
    {
        public string Symbol { get; set; }

        private decimal _value { get; set; }

        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.Notify();
            }
        }

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
