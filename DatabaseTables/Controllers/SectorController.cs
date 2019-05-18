using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseTables.Models;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DatabaseTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly DataContext _context;

        public SectorController(DataContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Sector>> GetData()
        {
            return _context.Status; // Return the whole table. 
        }

        [HttpGet("{id}")]
        public ActionResult<Sector> GetDataById(int id)
        {
            var commandItem = _context.Status.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }

        // POST: api/commands
       /*
        [HttpPost]
        public ActionResult<Data> PostData(Data command)
        {
            _context.VoltValues.Add(command); // Adding to the database.
            _context.SaveChanges(); // When you save something to the database. 

            return CreatedAtAction("PostData", new Command { Id = command.Id }, command);
        }
        */

        // PUT: api/commands/n
        /*
        [HttpPut("{id}")]
        public ActionResult PutData(int id, Data command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
        */

        // DELETE: api/commands/n
        /*
        [HttpDelete("{id}")]
        public ActionResult<Data> DeleteData(int id)
        {
            var commandItem = _context.VoltValues.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _context.DataValues.Remove(commandItem);
            _context.SaveChanges();

            return commandItem;
        }
        */
    }
}