using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTables.Models
{
    /// <summary>
    /// Represent the sectors in the silicon detector. 
    /// </summary>
    public class Sector
    {
        [Key]
        public int SectorNumber { get; set; }
        public bool Status1 { get; set; }
        public bool Status2 { get; set; }
        public bool Status3 { get; set; }
        public bool Status4 { get; set; }
        public bool Status5 { get; set; }
        public bool Status6 { get; set; }
        public bool Status7 { get; set; }
        public bool Status8 { get; set; }
        public bool Status9 { get; set; }
    }
}
