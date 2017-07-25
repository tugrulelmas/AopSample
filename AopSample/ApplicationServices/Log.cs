using System;

namespace AopSample.ApplicationServices
{
    public class Log : ILog
    {
        public void Debug(string message) {
            Console.WriteLine(message);
        }

        public void Error(string message) {
            Console.WriteLine(message);
        }
    }
}