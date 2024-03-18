using System;
using System.Threading;

class DeadlockExample
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();

    static void Thread1Method()
    {
        lock (lock1)
        {
            Console.WriteLine("Thread 1 acquired lock1");
            Thread.Sleep(100); // 다른 쓰레드가 lock2를 획득할 시간을 제공
            lock (lock2)
            {
                Console.WriteLine("Thread 1 acquired lock2");
            }
        }
    }

    static void Thread2Method()
    {
        lock (lock2)
        {
            Console.WriteLine("Thread 2 acquired lock2");
            Thread.Sleep(100); // 다른 쓰레드가 lock1을 획득할 시간을 제공
            lock (lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1");
            }
        }
    }

    static void Main(string[] args)
    {
        Thread t1 = new Thread(new ThreadStart(Thread1Method));
        Thread t2 = new Thread(new ThreadStart(Thread2Method));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}