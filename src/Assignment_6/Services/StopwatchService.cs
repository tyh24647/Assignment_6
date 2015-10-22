using System.Diagnostics;
using System.Text;

namespace Assignment_6.Services {
    /**
    * This class times how long passes between events.
    */
    public class StopwatchService {

        private ILogger logger;

        private Stopwatch stopwatch = new Stopwatch();

        private StringBuilder builder = new StringBuilder();

        public void Start(string name, ILogger logger) {
            this.logger = logger;
            logger.Log("Starting a new stopwatch");
            Lap(name);
            stopwatch.Start();
        }

        public void Lap(string name) {
            builder.Append("{").Append(name).Append(" ").Append(stopwatch.ElapsedTicks).Append("}");
        }

        public override string ToString() {
            return builder.ToString();
        }
    }
}
