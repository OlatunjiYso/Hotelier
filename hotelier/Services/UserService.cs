using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using hotelier.Helpers;
using hotelier.Models;
using hotelier.Data;
using hotelier.DTOs;

namespace hotelier.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(RegisterReq user);
        void Update(UserUpdateReq user);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private HotelierContext _context;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, HotelierContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
            //return _context.Users.Find(id);
        }

        public User Create(RegisterReq registerReq) 
        {
            if(string.IsNullOrWhiteSpace(registerReq.Password))
                throw new AppException("Password is required");
            if(string.IsNullOrWhiteSpace(registerReq.Email))
                throw new Exception("Email is required");
            var existingUser = _context.Users.Any<User>(u => u.Email == registerReq.Email);
            if(existingUser) 
                throw new Exception("This email is taken");
            byte [] passwordHash, passwordSalt;
            CreatePasswordHash(registerReq.Password, out passwordHash, out passwordSalt);

            User newUser =  new User();
                newUser.Email=registerReq.Email;
                 newUser.Lastname= registerReq.Lastname;
                 newUser.Firstname= registerReq.Firstname;
                  newUser.PasswordHash= passwordHash;
                  newUser.PasswordSalt =  passwordSalt;
                   newUser.Role = "User";
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public void Update (UserUpdateReq updateReq) {

            User user = _context.Users.FirstOrDefault((u)=> u.Id == updateReq.Id);
            if (user == null) throw new AppException("user no found");
            //checked for unique fields among users
            if(!string.IsNullOrWhiteSpace(updateReq.Email)) {
               bool existingMailHolder =  _context.Users.Any((u)=> u.Email == updateReq.Email);
               if(existingMailHolder) throw new AppException("Email is taken");
               user.Email = updateReq.Email;
            }
            if(!string.IsNullOrWhiteSpace(updateReq.Lastname)) { 
                user.Lastname = updateReq.Lastname;
            }
            if(!string.IsNullOrWhiteSpace(updateReq.Firstname)) { 
                user.Firstname = updateReq.Firstname;
            }
            if(!string.IsNullOrWhiteSpace(updateReq.Role)) {
                user.Role = updateReq.Role;
            }
            if(!string.IsNullOrWhiteSpace(updateReq.Password)) {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(updateReq.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id) {
             User user = _context.Users.FirstOrDefault((u)=> u.Id == id);
            if (user == null) throw new AppException("user no found");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }




        // helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)  {
            if(password == null)  throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            } 
             using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

         public static void StaticCreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)  {
            if(password == null)  throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            } 
             using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

         private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("name", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}