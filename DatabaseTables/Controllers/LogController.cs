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

        // PUT: api/commands/n
        [HttpPut("{id}")]
        public ActionResult<Log> PostData(int id, Sector command)
        {
            var row = _context.Clicks.Find(1);

            row.Clicks += id;

            _context.SaveChanges();

            return NoContent();
        }
    }
}