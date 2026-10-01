using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.SocialMedia
{
    public class SocialMediaViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
