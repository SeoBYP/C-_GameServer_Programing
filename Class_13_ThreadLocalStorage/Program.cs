using System;
using System.Threading;

class TLSDemo
{
    // ThreadLocal<int> 인스턴스를 생성합니다. 각 쓰레드는 자신만의 카운터 값을 갖게 됩니다.
    private static ThreadLocal<int> _counter = new ThreadLocal<int>(() => 0);

    public static void Main()
    {
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                // 카운터를 10까지 증가시키며, 각 쓰레드는 독립적인 카운터 값을 갖습니다.
                for (int j = 0; j <= 10; j++)
                {
                    _counter.Value++;
                    Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}, Counter: {_counter.Value}");
                }
            });
            threads[i].Start();
        }

        foreach (Thread t in threads)
        {
            t.Join();
        }
    }
}