namespace DemoMultithreadingCooking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Cooking Show!");

            Kitchen kitchen = new();
            Console.WriteLine(nameof(kitchen.CookBreakfast) + "Before Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);

            await kitchen.CookBreakfast();
            Console.WriteLine(nameof(kitchen.CookBreakfast) + "After Task.Run" + " Thread ID: " + Environment.CurrentManagedThreadId);
        }
    }
}
