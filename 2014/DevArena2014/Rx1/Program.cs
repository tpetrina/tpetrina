using System;

namespace Rx1
{
    public class SimpleEvent
    {
        public event EventHandler Hello;

        protected void RaiseHello()
        {
            if (Hello != null)
                Hello.Invoke(this, EventArgs.Empty);
        }

        public void Say()
        {
            RaiseHello();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var simpleEvent = new SimpleEvent();
            simpleEvent.Hello += simpleEvent_Hello;
            simpleEvent.Say();

            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void simpleEvent_Hello(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }
    }
}
