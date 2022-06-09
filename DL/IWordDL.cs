using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public interface IWordDL
    {
         Task<List<Word>> GetDL();
        Task<List<Word>> GetDL(int categoryId);
    };
}
