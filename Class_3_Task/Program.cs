using System;
using System.Threading.Tasks;

class Program
{
    // static async Class_3_Task Main(string[] args)
    // {
    //     await Class_3_Task.Run(() => 
    //     {
    //         // 비동기적으로 실행될 작업
    //         Console.WriteLine("Hello from a task!");
    //     });
    //     
    //     Console.WriteLine("Main thread work is done.");
    // }
    
    static async Task Main(string[] args)
    {
        int result = await CalculateResultAsync();
        Console.WriteLine($"Result: {result}");
    }

    static async Task<int> CalculateResultAsync()
    {
        return await Task.Run(() =>
        {
            // 복잡한 계산을 수행
            return 123;
        });
    }
}