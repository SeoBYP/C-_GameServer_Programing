using System;
using System.Threading;

class AutoResetEventExample
{
    private static AutoResetEvent autoEvent = new AutoResetEvent(false);

    static void Main(string[] args)
    {
        Console.WriteLine("메인 쓰레드: 작업자 쓰레드 시작 요청");
        Thread worker = new Thread(WorkerThread);
        worker.Start();

        Console.WriteLine("메인 쓰레드: 작업자 쓰레드의 작업 완료 대기");
        autoEvent.WaitOne();
        Console.WriteLine("메인 쓰레드: 작업자 쓰레드의 작업 완료 확인");
    }

    static void WorkerThread()
    {
        Console.WriteLine("작업자 쓰레드: 작업 시작");
        Thread.Sleep(5000); // 가상의 작업 시간
        Console.WriteLine("작업자 쓰레드: 작업 완료");

        // 작업 완료를 메인 쓰레드에 신호
        autoEvent.Set();
    }
}
;