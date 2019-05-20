using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DatabaseTables.Models;
using DatabaseTables.Helpers;
using Microsoft.IdentityModel.Logging;

namespace DatabaseTables.Services
{
    public class UserService
    {
        // Should be in the database later. 
        // Hardcoded for simplicity. 
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Håkon", LastName = "Olsen", Username = "aliceadmin", Password = "aliceadmin2019", Role = Role.Admin },
            new User { Id = 2, FirstName = "Marius", LastName = "Knutsen", Username = "aliceuser", Password = "aliceuser2019", Role = Role.User }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // To allow operators log-in to the interface as either admin or user.  
        public User AuthenticateUser(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // User does not exist. Return nothing. 
            if (user == null)
                return null;

            // Generate JWT token.
            var tokenCreater = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            IdentityModelEventSource.ShowPII = true;
            var token = tokenCreater.CreateToken(tokenDescriptor);
            user.Token = tokenCreater.WriteToken(token);

            // Remove the password before returning. 
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }

        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            // return user without password
            if (user != null)
                user.Password = null;

            return user;
        }
    }
}