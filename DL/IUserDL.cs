using SignLanguage.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User> GetDL(string email, string password);
        Task<User> PostDL(User user);
        Task PutDL(int id, User userToUpdate);
        Task<User> getLoginData(string email);
    }
}
