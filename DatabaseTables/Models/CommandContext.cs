using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTables.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Command> CommandItems { get; set; }

        /// <summary>
        /// User method for database. 
        /// </summary>
        public DbSet<User> Users { get; set;  }
    }
}

