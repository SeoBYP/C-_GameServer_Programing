using System;
using System.Threading;

class MemoryBarrierExample
{
    static int a = 0;
    static bool flag = false;

    static void Thread1()
    {
        // 값 설정
        a = 1;
        // 메모리 배리어: 이 지점에서 모든 쓰기(Store) 연산이 완료되도록 보장
        Thread.MemoryBarrier();
        // 플래그 설정
        flag = true;
    }

    static void Thread2()
    {
        // flag 값이 true로 설정되었는지 확인
        if (flag)
        {
            // 메모리 배리어: 이 지점에서 모든 읽기(Load) 연산이 완료되도록 보장
            Thread.MemoryBarrier();
            // flag가 true일 때 a의 값 출력
            Console.WriteLine(a);
        }
    }

    static void Main(string[] args)
    {
        // Thread1과 Thread2를 동시에 실행
        Thread t1 = new Thread(new ThreadStart(Thread1));
        Thread t2 = new Thread(new ThreadStart(Thread2));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        
        // 결과
        // Final counter value: 20000
    }
}