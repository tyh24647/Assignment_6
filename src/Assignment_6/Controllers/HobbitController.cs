using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Assignment_6.Filters;
using Assignment_6.Services;

namespace Assignment_6.Controllers {
    /*
	* The main endpoint controller. Stores and allows updates to a list of strings (hobbit names).
	*/
    [Route("api/[controller]")]
    [TypeFilter(typeof(StopwatchFilter))]
    [TypeFilter(typeof(RequestIdFilter))]
    public class HobbitController : Controller {

        private IDatabase database;
        
        private static ILogger logger;

        private static StopwatchService watchService;
        
        public HobbitController(ILogger logger, IDatabase database, StopwatchService watchService) {
            HobbitController.logger = logger;
            this.database = database;
            HobbitController.watchService = watchService;
        }

        [HttpGet]
        public IEnumerable<string> Get() {
            logger.Log("GET hobbits returning " + database.Size);
            watchService.Lap("Controller");
            return database.GetData("Hobbit");
        }

        [HttpPost]
        public string Post([FromQuery] string hobbit) {
            logger.Log("POST hobbits adding " + hobbit);
            watchService.Lap("Controller");
            database.AddString("Hobbit", hobbit);
            return hobbit;
        }
    }
}
