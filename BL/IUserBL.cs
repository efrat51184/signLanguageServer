using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL
{
    public interface IUserBL
    {
        Task<User> GetBL(string email, string password);
        Task<User> PostBL(User user);
        Task PutBL(int id, User user);
    }
}
