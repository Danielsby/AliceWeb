using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseTables.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DatabaseTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Temperature>> GetData()
        {
            return _context.TemperatureValues; // Return the whole table. 
        }

        [HttpGet("{id}")]
        public ActionResult<Temperature> GetDataById(int id)
        {
            var commandItem = _context.TemperatureValues.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }
            
            return commandItem;
        }

        /*
        [HttpPost]
        public ActionResult<Temperature> PostData(Temperature command)
        {
            _context.TemperatureValues.Add(command); // Adding to the database.
            _context.SaveChanges(); // When you save something to the database. 

            return CreatedAtAction("PostData", new Command { OneHour = command.OneHour }, command);
        }
        */

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

        /*
        [HttpDelete("{id}")]
        public ActionResult<Data> DeleteData(int id)
        {
            var commandItem = _context.TemperatureValues.Find(id);
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