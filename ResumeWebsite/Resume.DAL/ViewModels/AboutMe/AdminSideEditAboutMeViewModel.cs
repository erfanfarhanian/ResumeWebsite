using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.AboutMe
{
    public class AdminSideEditAboutMeViewModel
    {
        #region Properties

        public int ID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string? LastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        [EmailAddress(ErrorMessage = "لطفا فرمت ایمیل معتبر وارد کنید.")]
        public string? Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string? Mobile { get; set; }

        [Display(Name = "سمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string? Position { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public DateOnly? BirthDate { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string? Location { get; set; }

        [Display(Name = "بیوگرافی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد.")]
        public string Bio { get; set; }

        [Display(Name = "نام پروفایل")]
        public string? ImageName { get; set; }

        [Display(Name = "پروفایل")]
        public IFormFile? Avatar { get; set; }

        #endregion

    }

    public enum AdminSiteEditAboutMeResult
    {
        Success,
        Error, 
        NotFound
    }
}
