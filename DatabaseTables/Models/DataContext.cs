using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTables.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Temperature> TemperatureValues { get; set; }
        public DbSet<Sector> Status { get; set; }
        public DbSet<User> Users { get; set;  }
        public DbSet<Log> Clicks { get; set; }
    }
}

