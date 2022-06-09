using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DL
{
    public class UserDL : IUserDL
    {
        SignLanguageDBContext SignLanguageDBContext;
        public UserDL(SignLanguageDBContext _SignLanguageDBContext)
        {
            SignLanguageDBContext = _SignLanguageDBContext;
        }
        public async Task<User> GetDL(string email, string password)
        {
            User u = await SignLanguageDBContext.Users.SingleOrDefaultAsync(u => u.UserEmail == email && u.UserPassword == password);
            return u;
    
        }
        public async Task<User> PostDL(User user)
        {
          await  SignLanguageDBContext.Users.AddAsync(user);
            await SignLanguageDBContext.SaveChangesAsync();
            return user;
        }
        public async Task PutDL(int id, User userToUpdate)
        {
       User user= await SignLanguageDBContext.Users.FindAsync(id);
            SignLanguageDBContext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await SignLanguageDBContext.SaveChangesAsync();
        }


        public async Task<User> getLoginData(string email)
        {
            return await SignLanguageDBContext.Users.Where(user => user.UserEmail == email).FirstOrDefaultAsync();

        }
    }
}
