using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTables.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly DataContext _context;

        public ResetController(DataContext context) => _context = context;

        [HttpPut("{id}")]
        public ActionResult<Log> ResetClick(int id, Log command)
        {
            var row = _context.Clicks.Find(1);

            row.Clicks = id;

            _context.SaveChanges();

            return NoContent();
        }
    }
}