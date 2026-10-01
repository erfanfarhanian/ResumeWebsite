using Resume.DAL.ViewModels.Common;
using Resume.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.SocialMedia
{
    public class FilterSocialMediaViewModel : BasePaging<SocialMediaViewModel>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "آیکون")]
        public string Icon { get; set; }

        [Display(Name = "آدرس")]
        public string Url { get; set; }
    }
}
