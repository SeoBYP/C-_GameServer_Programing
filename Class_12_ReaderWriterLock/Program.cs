using System;
using System.Threading;

class ReaderWriterLockExample
{
    private static ReaderWriterLock rwLock = new ReaderWriterLock();
    private static int sharedData = 0;

    public static void ReadData()
    {
        try
        {
            rwLock.AcquireReaderLock(Timeout.Infinite);
            Console.WriteLine($"Reading data: {sharedData}");
        }
        finally
        {
            rwLock.ReleaseReaderLock();
        }
    }

    public static void WriteData(int value)
    {
        try
        {
            rwLock.AcquireWriterLock(Timeout.Infinite);
            sharedData = value;
            Console.WriteLine($"Writing data: {sharedData}");
        }
        finally
        {
            rwLock.ReleaseWriterLock();
        }
    }

    static void Main()
    {
        // 쓰기 작업을 수행하는 쓰레드
        Thread writerThread = new Thread(() => WriteData(42));
        writerThread.Start();
        writerThread.Join();

        // 읽기 작업을 수행하는 쓰레드들
        Thread[] readerThreads = new Thread[5];
        for (int i = 0; i < readerThreads.Length; i++)
        {
            readerThreads[i] = new Thread(ReadData);
            readerThreads[i].Start();
        }

        foreach (var t in readerThreads)
        {
            t.Join();
        }
    }
}