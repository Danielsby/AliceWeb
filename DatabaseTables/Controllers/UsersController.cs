using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authentication;
using DatabaseTables.Services;
using DatabaseTables.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace DatabaseTables.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // private const string V = "http://localhost:5000";
        // private readonly CommandContext _context;
        // public UsersController(CommandContext context) => _context = context;

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [EnableCors]
        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser([FromBody]User userParam)
        {
            // Send from database instead.
            var user = _userService.AuthenticateUser(userParam.Username, userParam.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is not correct. Please try again. " });
            }

            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [EnableCors]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [EnableCors]
        [HttpGet("{id}")]
        public IActionResult GetIdUser(int id)
        {
            var user = _userService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            // Only allow admins to access other user recoreds.
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}