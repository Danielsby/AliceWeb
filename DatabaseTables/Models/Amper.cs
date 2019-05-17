using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTables.Models
{
    public class Amper
    {
        [Key]
        public int OneHour { get; set; }
        public string TwoHours { get; set; }
        public string ThreeHours { get; set; }
        public string FourHours { get; set; }
    }
}
