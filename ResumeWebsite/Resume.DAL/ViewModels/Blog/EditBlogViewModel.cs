using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Blog
{
    public class EditBlogViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ مطلب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(25, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string? BlogDate { get; set; }

        [Display(Name = "متن کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortText { get; set; }

        [Display(Name = "متن بلند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LongText { get; set; }

        [Display(Name = "تصویر")]
        public string? ImageUrl { get; set; }

        [Display(Name = "تصویر مطلب")]
        public IFormFile? Avatar { get; set; }
    }

    public enum EditBlogResult
    {
        Success,
        Error,
        NotFound
    }
}
