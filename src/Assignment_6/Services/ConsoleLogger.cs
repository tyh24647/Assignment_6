using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_6.Services {
    public class ConsoleLogger : ILogger {

        private static ConsoleLogger instance = new ConsoleLogger();

        public static ConsoleLogger Instance { get { return instance; } }

        public ConsoleLogger() {
            if (instance != null) {
                throw new InvalidOperationException("Tried to create a second ConsoleLogger. That's bad.");
            }
        }

        public void Log(string message) {
            Console.WriteLine(message);
        }
    }
}
