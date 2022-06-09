using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public class WordDL: IWordDL
    {

        SignLanguageDBContext SignLanguageDBContext;
        public WordDL(SignLanguageDBContext _SignLanguageDBContext)
        {
            SignLanguageDBContext = _SignLanguageDBContext;
        }
       public async Task<List<Word>> GetDL()
        {
            List<Word> lword = await SignLanguageDBContext.Words.ToListAsync();
         
            return lword;
        }
        public async Task<List<Word>> GetDL(int categoryId)
        {
            List<Word> lword = await SignLanguageDBContext.Words.Where(w => w.CategoryId== categoryId).ToListAsync();
            return lword;        }
    }
}
