using DL;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;
        public IConfiguration _configuration;
        IPasswordHashHelper _passwordHashHelper;

        public UserBL()
        {
        }
        public UserBL(IUserDL userDL, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
            this.userDL = userDL;
            _configuration = configuration;
            _passwordHashHelper = passwordHashHelper;
        }
        public async Task<User> GetBL(string email, string password)
        {

            User user = await userDL.getLoginData(email);
            string Hashedpassword = _passwordHashHelper.HashPassword(password, user.UserSalt, 1000, 8);
            if (Hashedpassword.Equals(user.UserPassword.TrimEnd()))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)








                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token)
                    ;// return await userDL.GetDL(email, password);
                return WithoutPassword(user);
            }
            else
                return null;


        }

        public static List<User> WithoutPasswords(List<User> users)
        {
            return users.Select(x => WithoutPassword(x)).ToList();
        }


        public static User WithoutPassword(User user)
        {
            user.UserPassword = null;
            return user;
        }
        public async Task<User> PostBL(User user)
        {
            user.UserSalt = _passwordHashHelper.GenerateSalt(8);
            user.UserPassword = _passwordHashHelper.HashPassword( user.UserPassword, user.UserSalt, 1000, 8);
            return await userDL.PostDL(user);
        }
        public async Task PutBL(int id, User user)
        {

            await userDL.PutDL(id, user);
        }

    }
}
