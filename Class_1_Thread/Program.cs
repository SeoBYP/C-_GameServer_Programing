using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread t = new Thread(new ThreadStart(Run));
        t.Start();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Main thread: Do some work.");
            Thread.Sleep(0);
        }

        t.Join();
        Console.WriteLine("Main thread: Run() method complete.");
        
        // 결과
        // Secondary thread: Running...
        // Main thread: Do some work.
        // Main thread: Do some work.
        // Main thread: Do some work.
        // Main thread: Do some work.
        // Main thread: Do some work.
        // Secondary thread: Running...
        // Secondary thread: Running...
        // Secondary thread: Running...
        // Secondary thread: Running...
        // Main thread: Run() method complete.
    }

    static void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Secondary thread: Running...");
            Thread.Sleep(0);
        }
    }
}