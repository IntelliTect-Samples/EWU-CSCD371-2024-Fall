
using System.Diagnostics;

namespace DemoMultithreadingCooking;

public class Kitchen
{
    private Stopwatch _stopwatch = new();
    public async Task CookBreakfast()
    {
        _stopwatch.Start();
        Console.WriteLine(nameof(CookEggs) + "Before Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        Task cookEggsTask = CookEggs();
        Console.WriteLine(nameof(CookBacon) + "Before Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        Task cookBaconTask = CookBacon();
        Console.WriteLine(nameof(CookToast) + "Before Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        Task cookToastTask = CookToast();

        await Task.WhenAll(cookEggsTask, cookBaconTask, cookToastTask);
        Console.WriteLine("Breakfast Meals are cooked" + "After Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        _stopwatch.Stop();
        Console.WriteLine($"Total time: " + _stopwatch.Elapsed.ToString(@"m\:ss\.fff"));
        Console.WriteLine("Breakfast is ready!");
    }

    private Task CookToast()
    {
        return Task.Run(async () =>
        {
            Console.WriteLine(nameof(CookToast) + " Thread ID: " + Environment.CurrentManagedThreadId);
            Console.WriteLine("Start cooking toast");

            await Task.Delay(2000);

            Console.WriteLine("Toast is ready");
        });
    }

    private Task CookEggs()
    {
        return Task.Run(async () =>
        {
            Console.WriteLine(nameof(CookEggs) + " Thread ID: " + Environment.CurrentManagedThreadId);
            Console.WriteLine("Start cooking eggs");
            await Task.Delay(3000);
            Console.WriteLine("Eggs are ready");
        });
    }

    private Task CookBacon()
    {
        return Task.Run(async () =>
        {
            Console.WriteLine(nameof(CookBacon) + " Thread ID: " + Environment.CurrentManagedThreadId);

            Console.WriteLine("Start cooking bacon");
            await Task.Delay(3000);
            Console.WriteLine("Bacon is ready");
        });
    }
}