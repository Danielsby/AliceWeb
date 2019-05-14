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
    /// <summary>
    /// This controller will represent the testdata. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context) => _context = context;

        // GET: api/commands.
        /// <summary>
        /// Retrieve the data. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Temperature>> GetData()
        {
            return _context.TemperatureValues; // Return the whole table. 
        }

        // GET: api/commands/n
        /// <summary>
        /// Retrieve the row based on the id-number. 
        /// </summary>
        /// <param name="id">id of the data-row.</param>
        /// <returns>The object with the parameter id. </returns>
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

        // POST: api/commands
        /// <summary>
        /// Add data.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /*
        [HttpPost]
        public ActionResult<Data> PostData(Data command)
        {
            _context.TemperatureValues.Add(command); // Adding to the database.
            _context.SaveChanges(); // When you save something to the database. 

            return CreatedAtAction("PostData", new Command { Id = command.Id }, command);
        }
        */

        // PUT: api/commands/n
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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