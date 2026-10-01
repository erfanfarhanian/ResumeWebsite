using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Blog
{
    public class Blog : BaseEntity<int>
    {
        public string Title { get; set; }
        public string? BlogDate { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public string? ImageUrl { get; set; }
    }
}
