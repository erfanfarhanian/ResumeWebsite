using Resume.DAL.ViewModels.Common;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Experience
{
    public class FilterExperienceViewModel : BasePaging<ExperienceViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "از تاریخ")]
        public DateOnly? StartDate { get; set; }

        [Display(Name = "تا تاریخ")]
        public DateOnly? EndDate { get; set; }
    }
}
