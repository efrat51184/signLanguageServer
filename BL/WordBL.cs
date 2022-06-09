using DL;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
namespace BL
{
    public class WordBL : IWordBL
    {
        IWordDL wordDL;
        public WordBL()
        {

        }
        public WordBL(IWordDL wordDL)
        {
            this.wordDL = wordDL;
        }
        public async Task<List<Word>> GetBL()
        {
            return await wordDL.GetDL();
        }
        public async Task<List<Word>> GetBL(int categoryId)
        {
            return await wordDL.GetDL(categoryId);
        }
    }
    
}
