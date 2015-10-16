using Microsoft.AspNet.Mvc;
using Assignment_6.Services;


namespace Assignment_6.Filters {
    public class RequestIdFilter : IActionFilter {

        private string localId;

        public RequestIdFilter() {
            localId = "local-id";
        }

        public string Id { get { return Id; } }

        public void OnActionExecuted(ActionExecutedContext context) {
            /*
            * TODO: This should use an IRequestIdGenerator
            */
            ConsoleLogger.Instance.Log("Adding a request-id to the response: "
                + localId);
            context.HttpContext.Response.Headers.Add("request-id", new string[] { localId });
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
