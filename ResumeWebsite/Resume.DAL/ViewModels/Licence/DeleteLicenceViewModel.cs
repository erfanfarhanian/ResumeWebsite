using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Licence
{
    public class DeleteLicenceViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ صدور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string IssueDate { get; set; }

        [Display(Name = "نام موسسه یا آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Institute { get; set; }
    }

    public enum DeleteLicenceResult
    {
        Success,
        Error,
        NotFound
    }
}
