using System;
using System.Threading;

class ContextSwitchExample
{
    static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {i}");
            // 컨텍스트 스위칭을 유도하기 위해 각 반복마다 잠시 대기
            Thread.Sleep(10);
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(PrintNumbers);
        Thread t2 = new Thread(PrintNumbers);
        t1.Start();
        t2.Start();
    }
}