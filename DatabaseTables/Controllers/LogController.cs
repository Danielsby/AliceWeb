using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseTables.Models;

namespace DatabaseTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly DataContext _context;

        public LogController(DataContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Log>> GetData()
        {
            return _context.Clicks;
        }
 
        [HttpPost]
        public ActionResult<Log> PostData(Log command)
        {
            _context.Clicks.Add(command); // Adding to the database.
            _context.SaveChanges(); // When you save something to the database. 

            return CreatedAtAction("PostData", new Log { Clicks = command.Clicks }, command);
        }
    }
}