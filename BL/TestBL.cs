using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL
{
   public class TestBL:ITestBL
    {
        IWordDL wordDL;
        public TestBL(IWordDL wordDL)
        {
            this.wordDL = wordDL;
        }
    }
}
