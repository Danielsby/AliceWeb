using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        [HttpGet("test")]
        public IActionResult testMethod()
        {
            return StatusCode(300);
        }
    }
}