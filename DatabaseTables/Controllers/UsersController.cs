using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authentication;
using DatabaseTables.Services;
using DatabaseTables.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace DatabaseTables.Controllers
{
    /// <summary>
    /// Defines and handles all routes. 
    /// Within each route the controller calls the user service to perform the action required.
    /// On successful authentication the authenticate method generates a JWT using JwtSecurityTokenHandler class. 
    /// It generates a token, digital signed by using the secret key in appsettings.json. 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // private const string V = "http://localhost:5000";

        // private readonly CommandContext _context;

        // public UsersController(CommandContext context) => _context = context;

        private IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userParam"> username and password from body. </param>
        /// <returns> Status based on the userparams. </returns>
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

        /// <summary>
        /// To check the users status.  
        /// </summary>
        /// <returns>All users</returns>
        [Authorize(Roles = Role.Admin)]
        [EnableCors]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// To check if the user exist. 
        /// </summary>
        /// <param name="id"> The ID of the user. </param>
        /// <returns> The selected user based on the ID. </returns>
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