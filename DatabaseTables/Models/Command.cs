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
    public class Command
    {
        public int Id { get; set; }
        public string Howto { get; set; }
        public string Platform { get; set; }
        public string CommandLine { get; set; }
    }
}
