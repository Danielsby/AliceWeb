using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace DatabaseTables.Helpers
{
    /// <summary>
    /// Accessing application settings via objects. 
    /// For example: The Users Controller accesses app settings via an IOptions<Appsettings> 
    /// </summary>
    public class AppSettings
    {
        public string Secret { get; set; }
    }
}
