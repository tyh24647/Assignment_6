using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Assignment_6.Filters;
using Assignment_6.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_6.Controllers {/*
	* The main endpoint controller. Stores and allows updates to a list of strings (hobbit names).
	*/
    [Route("api/[controller]")]
    [TypeFilter(typeof(StopwatchFilter))]
    [TypeFilter(typeof(RequestIdFilter))]
    public class HobbitController : Controller {
        /*
		* TODO: Get the MemoryDatabase from DependencyInjection instead.
		*/
        private MemoryDatabase database = new MemoryDatabase();

        /*
		* TODO: Get the StopwatchService from DependencyInjection instead.
		*/
        private StopwatchService watchService = new StopwatchService();

        [HttpGet]
        public IEnumerable<string> Get() {
            /*
			* TODO: Shouldn't be using ConsoleLogger directly. What if we wanted to use a different type of logger?
			*/
            ConsoleLogger.Instance.Log("GET hobbits returning " + database.Size);
            watchService.Lap("Controller");

            return database.GetData("Hobbit");
        }

        [HttpPost]
        public string Post([FromQuery] string hobbit) {
            /*
			* TODO: Shouldn't be using ConsoleLogger directly. What if we wanted to use a different type of logger?
			*/
            ConsoleLogger.Instance.Log("POST hobbits adding " + hobbit);
            watchService.Lap("Controller");

            database.AddString("Hobbit", hobbit);

            return hobbit;
        }
    }
}
