using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Blog
{
    public class BlogViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string? BlogDate { get; set; }

        public string ShortText { get; set; }

        public string LongText { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
