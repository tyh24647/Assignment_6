using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_6.Services {
    public interface ILogger {
        //ConsoleLogger Instance { get; }
        void Log(string message);
    }
}
