//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DL;
//using Models

//namespace BL
//{
//    class TextBL
//    {
//        ITextDL TextDL;
//        public TextBL()
//        {

//        }
//        public TextBL(ITextDL TextDL)
//        {
//            this.TextDL = TextDL;
//        }
//        public async Task<List<Text>> GetBL()
//        {
//            return await TextDL.GetDL();
//        }
//        public async Task<List<Text>> GetBL(int TextId)
//        {
//            return await TextDL.GetDL(TextId);
//        }
//    }
//}
