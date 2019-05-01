using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseTables.Models;

namespace DatabaseTables.Controllers
{
    /// <summary>
    /// Dataflow. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context) => _context = context;

        // GET: api/commands.
        /// <summary>
        /// Retrieve the data. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }

        // GET: api/commands/n
        /// <summary>
        /// Retrieve the row based on the id-number. 
        /// </summary>
        /// <param name="id">id of the data-row.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

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
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("PostCommandItem", new Command { Id = command.Id }, command);
        }

        // PUT: api/commands/n
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/commands/n
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();

            return commandItem;
        }
    }
}