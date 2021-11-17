using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveExample
{
    public class Observer : IObserver
    {
        public Observer()
        {
            Custody = new List<Custody>();
        }

        public decimal Sum
        {
            get
            {
                return Custody.Sum(x => x.Quantity * x.Value);
            }
        }

        public List<Custody> Custody { get; set; }

        public void Update(ISubject subject)
        {
            if (subject is Observable observable)
            {
                Console.WriteLine($"Observer recebeu alteracao de {observable.Symbol} | {observable.Value}");

                var index = Custody.FindIndex(c => c.Symbol == observable.Symbol);

                Custody[index].Value = observable.Value;
            }
            else
            {
                Console.WriteLine($"xpto");
            }
        }
    }
}
