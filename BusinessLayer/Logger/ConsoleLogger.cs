using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Logger
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
           Console.WriteLine("ConsoleLogger - " + message);
        }
    }
}
