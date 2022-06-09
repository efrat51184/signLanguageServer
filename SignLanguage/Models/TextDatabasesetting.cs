using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Models
{
    public class TextDatabasesetting : ITextDatabaseSettings
    {
        public string TextCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }

   

}
