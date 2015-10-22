using Assignment_6.Services;
using Microsoft.AspNet.Mvc;

namespace Assignment_6.Filters {
    /* 
    * This class times how long a request takes to execute
    * and then adds the result to a response header.
    */
    public class StopwatchFilter : IActionFilter {
        
        private ILogger logger;

        static StopwatchService watchService;

        public StopwatchFilter(ILogger logger, StopwatchService watchService) {
            this.logger = logger;
            StopwatchFilter.watchService = watchService;
        }

        public void OnActionExecuted(ActionExecutedContext context) {
            watchService.Lap("Action Executed");
            context.HttpContext.Response.Headers.Add("stopwatch ", new string[] { watchService.ToString() });
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            watchService.Start("Action Executing", logger);
        }
    }
}
