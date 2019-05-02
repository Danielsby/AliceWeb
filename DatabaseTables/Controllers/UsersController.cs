using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.AspNetCore.Authentication;
using DatabaseTables.Services;
using DatabaseTables.Models;
using Microsoft.AspNetCore.Authorization;

namespace DatabaseTables.Controllers
{
    /// <summary>
    /// Defines and handles all routes. 
    /// Within each route the controller calls the user service to perform the action required.
    /// On successful authentication the authenticate method generates a JWT using JwtSecurityTokenHandler class. 
    /// It generates a token, digital signed by using the secret key in appsettings.json. 
    /// </summary>
    public class UsersController : ControllerBase
    {
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
        /// <param name="userParam"> Receives username and password from body. </param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        /// <summary>
        /// To check the users status.  
        /// </summary>
        /// <returns>All users</returns>
        [Authorize(Roles = Role.Admin)]
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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