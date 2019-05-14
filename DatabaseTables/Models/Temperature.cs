using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTables.Models;
namespace DatabaseTables.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Temperature
    {
        public int OneHour { get; set; }
        public string TwoHour { get; set; }
        public string ThreeHour { get; set; }
    }
}
