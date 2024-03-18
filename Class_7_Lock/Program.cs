using System;
using System.Threading;

class BankAccount
{
    private int balance;
    private readonly object balanceLock = new object();

    public BankAccount(int initialBalance)
    {
        balance = initialBalance;
    }

    // 예금
    public void Deposit(int amount)
    {
        lock (balanceLock)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount}, New Balance: {balance}");
        }
    }

    // 출금
    public void Withdraw(int amount)
    {
        lock (balanceLock)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount}, New Balance: {balance}");
            }
            else
            {
                Console.WriteLine("Withdrawal attempt failed due to insufficient funds.");
            }
        }
    }

    // 현재 잔액 조회
    public int GetBalance()
    {
        lock (balanceLock)
        {
            return balance;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000);

        // 출금을 시도하는 쓰레드
        Thread[] threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() => account.Withdraw(100));
            threads[i].Start();
        }

        // 모든 쓰레드가 완료될 때까지 대기
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
        // 결과
        // Withdrew 100, New Balance: 900
        // Withdrew 100, New Balance: 800
        // Withdrew 100, New Balance: 700
        // Withdrew 100, New Balance: 600
        // Withdrew 100, New Balance: 500
        // Withdrew 100, New Balance: 400
        // Withdrew 100, New Balance: 300
        // Withdrew 100, New Balance: 200
        // Withdrew 100, New Balance: 100
        // Withdrew 100, New Balance: 0
        // Final Balance: 0

        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
}