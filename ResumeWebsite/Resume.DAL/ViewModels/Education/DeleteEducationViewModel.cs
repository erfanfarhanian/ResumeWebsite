using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Education
{
    public class DeleteEducationViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Title { get; set; }

        [Display(Name = "از تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateOnly StartDate { get; set; }

        [Display(Name = "تا تاریخ")]
        public DateOnly? EndDate { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Description { get; set; }
    }

    public enum DeleteEducationResult
    {
        Success,
        Error,
        NotFound
    }
}
