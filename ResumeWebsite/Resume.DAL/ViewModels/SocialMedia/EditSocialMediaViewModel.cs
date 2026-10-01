using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.SocialMedia
{
    public class EditSocialMediaViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Title { get; set; }

        [Display(Name = "آیکون")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Icon { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Url { get; set; }
    }

    public enum EditSocialMediaResult
    {
        Success,
        Error,
        NotFound
    }
}
