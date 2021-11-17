using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer = new Observer();

            observer.Custody = new List<Custody>()
            {
                new Custody()
                {
                    Symbol = "PETR4",
                    Quantity = 1,
                    Value = 10
                },
                new Custody()
                {
                    Symbol = "VALE3",
                    Quantity = 1,
                    Value = 10
                }
            };

            Console.WriteLine($"Saldo eh de {observer.Sum}");

            var observable = new List<Observable>()
            {
                new Observable()
                {
                    Symbol = "PETR4",
                    Value = 10
                },
                new Observable()
                {
                    Symbol = "VALE3",
                    Value = 10
                },
            };

            foreach (var item in observable)
            {
                if (observer.Custody.Any(x => x.Symbol == item.Symbol))
                {
                    item.Attach(observer);
                }
            }

            Console.WriteLine($"Mudando a cotacao");

            observable[1].Value = 100;

            Console.WriteLine($"Saldo eh de {observer.Sum}");

            Console.ReadKey();
        }
    }
}
