using System;
using System.Threading;

public class ThreadPoolExample
{
    public static void Main()
    {
        // ThreadPool의 최소 및 최대 쓰레드 수를 설정합니다.
        ThreadPool.SetMinThreads(5, 5);
        ThreadPool.SetMaxThreads(10, 10);

        // 장시간 실행되는 작업을 여러 개 제출합니다.
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem(WorkItemMethod, i);
        }

        Console.WriteLine("모든 작업이 제출되었습니다. 메인 쓰레드는 계속 실행됩니다.");
        Thread.Sleep(1000); // 메인 쓰레드 대기
        Console.WriteLine("메인 쓰레드 종료.");
        
        // 결과
        // 모든 작업이 제출되었습니다. 메인 쓰레드는 계속 실행됩니다.
        // 작업 0 시작.
        // 작업 0 완료.
        // 작업 2 시작.
        // 작업 2 완료.
        // 작업 4 시작.
        // 작업 4 완료.
        // 작업 3 시작.
        // 작업 3 완료.
        // 작업 1 시작.
        // 작업 1 완료.
        // 메인 쓰레드 종료.
    }

    static void WorkItemMethod(Object stateInfo)
    {
        int taskNumber = (int)stateInfo;
        Console.WriteLine($"작업 {taskNumber} 시작.");

        // 장시간 실행을 시뮬레이션합니다. 실제 애플리케이션에서는 이러한 긴 대기 시간을 피해야 합니다.
        //Class_1_Thread.Sleep(10000);

        Console.WriteLine($"작업 {taskNumber} 완료.");
    }
}