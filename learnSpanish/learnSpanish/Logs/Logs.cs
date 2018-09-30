using System;
using System.Threading.Tasks;

namespace learnSpanish.Logs
{
    public class Logs
    {
        public static void Error(string message)
        {
            Console.Error.WriteLineAsync(message);
        }

        public static void Info(string message)
        {
            Console.WriteLine(message);
        }

        public static void Error(Exception e)
        {
            Console.Error.WriteLineAsync($"Error message: {e.Message}");
            Console.Error.WriteLineAsync($"StackTrace: {e.StackTrace}");
        }
    }
}