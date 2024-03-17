// See https://aka.ms/new-console-template for more information

class Program
{
    static void MakeThread(object state)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    static void Main(string[] args)
    {
        ThreadPool.SetMinThreads(1, 1);
        ThreadPool.SetMaxThreads(5, 5);

        // for (int i = 0; i < 4; i++)
        // {
        //     ThreadPool.QueueUserWorkItem((obj) =>
        //     {
        //         while (true)
        //         {
        //
        //         }
        //     });
        // }
        
        for (int i = 0; i < 5; i++)
        {
            Task t = new Task(() =>
            {
                while (true)
                {

                }
            });
            t.Start();
        }
        
        ThreadPool.QueueUserWorkItem(MakeThread);
        // for (int i = 0; i < 1000; i++)
        // {
        //     Thread t = new Thread(MakeThread);
        //     t.IsBackground = true; 
        //     t.Start();
        // }

        while (true)
        {
        
        }
    }

}

