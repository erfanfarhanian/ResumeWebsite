using Resume.DAL.ViewModels.Common;
using Resume.DAL.ViewModels.Licence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Skill
{
    public class FilterSkillViewModel : BasePaging<SkillViewModel>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "میزان تسلط (درصد)")]
        public Int16 Proficiency { get; set; }
    }
}
