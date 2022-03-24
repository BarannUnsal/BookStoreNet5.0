using System;

namespace WebApi.Services
{
    public class ConsoleLogger : ILogService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}