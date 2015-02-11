using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Rx2
{
    public class SimpleEvent
    {
        private readonly Subject<string> communication = new Subject<string>();

        public IObservable<string> Communication
        {
            get { return communication.AsObservable(); }
        }

        public void Say()
        {
            communication.OnNext("Hello");
        }

        //public void Done()
        //{
        //    communication.OnCompleted();
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var simpleEvent = new SimpleEvent();

            simpleEvent.Communication.Subscribe(Console.WriteLine);

            simpleEvent.Say();

            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
