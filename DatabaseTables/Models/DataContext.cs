using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTables.Models
{
    /// <summary>
    /// Where the class communicate with the database. 
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// For temperature 
        /// </summary>
        public DbSet<Temperature> TemperatureValues { get; set; }

        /// <summary>
        /// For Volt
        /// </summary>
        public DbSet<Amper> VoltValues { get; set; }

        /// <summary>
        /// For users. 
        /// </summary>
        public DbSet<User> Users { get; set;  }
    }
}

