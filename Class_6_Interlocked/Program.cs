using System;
using System.Threading;

class Program
{
    private static int counter = 0;

    static void Main(string[] args)
    {
        Thread t1 = new Thread(IncrementCounter);
        Thread t2 = new Thread(IncrementCounter);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Final counter value: {counter}");
        // 결과
        // Final counter value: 20000

    }

    static void IncrementCounter()
    {
        for (int i = 0; i < 10000; i++)
        {
            Interlocked.Increment(ref counter);
        }
    }
}