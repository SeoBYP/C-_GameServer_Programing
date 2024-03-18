using System;
using System.Threading;
using System.Threading.Tasks;

class SpinLockExample
{
    private static int sharedResource = 0;
    private static SpinLock spinLock = new SpinLock();

    public static void UpdateResource(int number)
    {
        bool lockTaken = false;
        try
        {
            // SpinLock 시도
            spinLock.Enter(ref lockTaken);
            // 공유 자원 업데이트
            sharedResource += number;
            Console.WriteLine($"Resource updated to {sharedResource} by {Task.CurrentId}");
        }
        finally
        {
            if (lockTaken)
            {
                // SpinLock 해제
                spinLock.Exit();
            }
        }
    }

    static void Main(string[] args)
    {
        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            int taskNumber = i;
            tasks[i] = Task.Run(() => UpdateResource(taskNumber));
        }

        Task.WaitAll(tasks);
        Console.WriteLine($"Final resource value: {sharedResource}");
    }
}