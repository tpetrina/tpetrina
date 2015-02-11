using System;
using System.Reactive.Linq;

namespace Rx3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(x =>
                {
                    Console.WriteLine(x);
                }))
            {
                while (Console.ReadKey().Key != ConsoleKey.Escape) ;
            }
        }
    }
}
