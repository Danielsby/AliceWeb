using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTables.Models
{
    public class Log
    {
        [Key]
        public int UserID { get; set; }
        public int Clicks { get; set; }
    }
}
