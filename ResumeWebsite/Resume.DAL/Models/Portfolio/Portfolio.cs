using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Portfolio
{
    public class Portfolio : BaseEntity<int>
    {
        public string Title { get; set; }
        public string? ProjectDate { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
