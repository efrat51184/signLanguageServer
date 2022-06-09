using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL
{
   public interface IWordBL
    {
        Task<List<Word>> GetBL();
        Task<List<Word>> GetBL(int categoryId);
    }
}
