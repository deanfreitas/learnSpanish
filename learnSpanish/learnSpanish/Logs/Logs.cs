using System;

namespace learnSpanish.Logs
{
    public class Logs
    {
        public static void Error(string message)
        {
            Console.Error.WriteLine(message);
        }

        public static void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}