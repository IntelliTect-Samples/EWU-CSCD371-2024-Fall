using System.Diagnostics;

namespace DemoMultithreadingCooking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new();
            Console.WriteLine("Welcome to the Cooking Show!");

            Kitchen kitchen = new();
            Console.WriteLine(nameof(kitchen.CookBreakfast) + "Before Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);

            stopwatch.Start();
            CancellationTokenSource cts = new();


            await Parallel.ForAsync(0, 10000, cts.Token, async (i, c) =>
            {
                Console.WriteLine("iteration: " + i);
                await kitchen.CookBreakfast(c);
            });
            //while (!parallelTask.Wait(100))
            //{
            //    Console.Read();
            //    // 
            //    cts.Cancel();
            //}
            //await parallelTask;
            stopwatch.Stop();
            Console.WriteLine($"Total time: " + stopwatch.Elapsed.ToString(@"m\:ss\.fff"));
            Console.WriteLine(nameof(kitchen.CookBreakfast) + "After Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        }
    }
}
