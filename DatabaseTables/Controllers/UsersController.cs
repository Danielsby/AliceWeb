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

        private UserService _userService;

        public UsersController(UserService userService)
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

        [Authorize(Roles = Role.Expert)]
        [EnableCors]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [EnableCors]
        [HttpGet("{id}")]
        public IActionResult GetIdUser(int id)
        {
            var user = _userService.GetUserById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            // Only allow admins to access other user recoreds.
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Expert))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}