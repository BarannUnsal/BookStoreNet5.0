using System;

namespace WebApi.Services
{
    public class DbLogger : ILogService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}