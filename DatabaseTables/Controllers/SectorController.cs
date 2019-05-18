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

        // PUT: api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutData(int id, Sector command)
        {
            /*
            if (id != command.SectorNumber)
            {
                return BadRequest();
            }
            */

            var row = _context.Status.Find(1);

            switch (id)
            {
                case 1:
                    row.Status1 = true;
                    break;
                case 2:
                    row.Status2 = true;
                    break;
                case 3:
                    row.Status3 = true;
                    break;
                case 4:
                    row.Status4 = true;
                    break;
                case 5:
                    row.Status5 = true;
                    break;
                case 6:
                    row.Status6 = true;
                    break;
                case 7:
                    row.Status7 = true;
                    break;
                case 8:
                    row.Status8 = true;
                    break;
                case 9:
                    row.Status9 = true;
                    break;
            }
            
            // _context.Entry(command).State = EntityState.Modified;
            // _context.Attach(command);
            // _context.Entry(command.Status4).Property("false").IsModified = true;
            _context.SaveChanges();

            return NoContent();
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