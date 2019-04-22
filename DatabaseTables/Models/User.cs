using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTables.Models
{
    public class User
    {
        public int ID { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
    }
}
