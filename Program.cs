using System;
using System.Collections.Generic;
using System.Threading;

namespace multithread
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        private void Run()
        {
            ThreadStart threadStart = new ThreadStart(OnThreadStart);
            List<Thread> threads = new List<Thread> 
            {
                new Thread(threadStart),
                new Thread(threadStart)
            };
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
        }
        private void OnThreadStart()
        {
            Random random = new Random();
            int randSleep = random.Next(1000, 5000);
            Thread.Sleep(randSleep);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine($" Thread n° {threadId} finished in {randSleep} milliseconds");
        }
    }
}
