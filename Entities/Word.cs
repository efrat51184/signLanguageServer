using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Word
    {
        public int WordId { get; set; }
        public int CategoryId { get; set; }
        public string NameWord { get; set; }
        public string SignWord { get; set; }
    }
}
