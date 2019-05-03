using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DatabaseTables.Services;
using DatabaseTables.Models;
using DatabaseTables.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

// Business logic, validation and database access code for users. 
namespace DatabaseTables.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly CommandContext _context;

        public UserService(CommandContext context) => _context = context;

        private IUserService _userService;

        /*
        private void CreateConnection()
        {
            string ConnStr = ConfigurationManager.ConnectionString["ConnStr"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
        }
        */


        // Users hardcoded for simplicity, store in a db with hashed password in production applicatiaons. 
        // TODO: Get this from the database. 
        // Get this from the database instead
        // Represent type of user. 
        private List<User> _user = new List<User>
        {
            new User { Id = 1, FirstName = "admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin},
            new User { Id = 1, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role = Role.User }
        };

        List<User> _userList = new List<User>();

        public void emptyList()
        {
            _userList = null;
        }

        public void fillList()
        { 
            int counter = 0;

            while (true)
            {
                // TODO: Use list instead.
                 _userList  _context.Users.Find(counter);

                if (commandItem == null)
                {
                    break; // The list is filled. 
                }

                counter++;
            }
        }
        
        // SQL Query.
        string sql = "SELECT * FROM users";
        // Connection string.
        string connString = "ConnectionString";

        // DataContext db = new DataContext("connectionstring");

        private readonly AppSettings _appSettings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSettings"></param>
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            // Update phase before authentication. 

            // Retrieve the current userdata from the database in here instead.
            // Empty the list. 
            emptyList();
            // Fill the list. 
            fillList();

            var user = _user.SingleOrDefault(x => x.Username == username && x.Password == password);

            // Return null if user not found.
            if (user == null)
                return null;

            // Authentication successful so generate jwt token.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role) 
                }),
                Expires = DateTime.UtcNow.AddDays(7), // 7 days expire-date. 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Remove password before returning. 
            user.Password = null;

            return user;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return _user.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> User. </returns>
        public User GetById(int id)
        {
            var user = _user.FirstOrDefault(x => x.Id == id);

            // Return user without password.
            if (user != null)
            {
                user.Password = null;
            }

            return user;
        }
    }
}
