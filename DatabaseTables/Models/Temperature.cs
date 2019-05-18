using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTables.Models;
namespace DatabaseTables.Models
{
    public class Temperature
    {
        [Key]
        public int TempID { get; set; }
        public int OneHour { get; set; }
        public int TwoHours { get; set; }
        public int ThreeHours { get; set; }
        public int fourHours { get; set; }
    }
}
