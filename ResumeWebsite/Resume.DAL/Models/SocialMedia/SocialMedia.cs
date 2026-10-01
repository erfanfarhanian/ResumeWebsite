using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.SocialMedia
{
    public class SocialMedia : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
