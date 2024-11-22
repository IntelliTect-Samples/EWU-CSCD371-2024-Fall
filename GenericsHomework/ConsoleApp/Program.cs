
namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            bool continueWaiting = true;
            List<char> spin = ['/', '-', '\\', '|'];
            int index = 0;
            Task<bool> checkingTask = Task.Run(() => WaitForUserEnterOrTimeoutAsync());
            do
            {
                Console.Clear();
                Console.Write(spin[index++]);

                continueWaiting = !checkingTask.Wait(100);

                index = (index + 1) % (spin.Count - 1);
            } while (continueWaiting);
        }

        private static bool WaitForUserEnterOrTimeoutAsync()
        {
            ConsoleKeyInfo foo = Console.ReadKey();
            return true;
        }
    }
}
