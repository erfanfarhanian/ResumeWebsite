using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Skill
{
    public class DeleteSkillViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز می باشد")]
        public string Title { get; set; }

        [Display(Name = "میزان تسلط (درصد)")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Int16 Proficiency { get; set; }
    }
    public enum DeleteSkillResult
    {
        Success,
        Error,
        NotFound
    }
}
