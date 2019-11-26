using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        [ThreadStatic]
        private static int counter;

        public static int Counter
        {
            get => counter; 
            set => counter = value; 
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Thread Demo!");
            int counts = 1000000;
            Thread a = new Thread(() =>
            {
                for (int i = 0; i < counts; i++)
                {
                    Counter = Counter + 1;
                }
            });
            Thread b = new Thread(() =>
            {
                for (int i = 0; i < counts; i++)
                {
                    Counter = Counter - 1;
                }
            });
            a.Start();
            b.Start();
            a.Join();
            b.Join();
            Console.WriteLine($"Counter: {Counter}");
        }
    }
}
