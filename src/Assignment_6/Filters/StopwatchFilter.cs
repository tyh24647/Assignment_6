using Assignment_6.Services;
using Microsoft.AspNet.Mvc;

namespace Assignment_6.Filters {

    /* 
    * This class times how long a request takes to execute
    * and then adds the result to a response header.
    */
    public class StopwatchFilter : IActionFilter {
        StopwatchService watchService = new StopwatchService();

        public void OnActionExecuted(ActionExecutedContext context) {
            watchService.Lap("Action Executed");
            context.HttpContext.Response.Headers.Add("stopwatch ", new string[] { watchService.ToString() });
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            watchService.Start("Action Executing");
        }
    }
}
