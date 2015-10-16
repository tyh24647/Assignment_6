using Microsoft.AspNet.Mvc;
using Assignment_6.Services;


namespace Assignment_6.Filters {
    public class RequestIdFilter : IActionFilter {

        private ILogger logger;

        private IRequestIdGenerator generator;

        private string localId;

        public RequestIdFilter(ILogger logger, IRequestIdGenerator generator) {
            this.logger = logger;
            this.generator = generator;
            localId = generator.Generate;
        }

        public string Id { get { return Id; } }

        public void OnActionExecuted(ActionExecutedContext context) {
            logger.Log("Adding a request-id to the response: " + localId);
            context.HttpContext.Response.Headers.Add("request-id", new string[] { localId });
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
