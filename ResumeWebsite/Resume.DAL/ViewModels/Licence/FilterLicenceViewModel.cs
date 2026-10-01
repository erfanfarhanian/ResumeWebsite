using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Licence
{
    public class FilterLicenceViewModel : BasePaging<LicenceViewModel>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تاریخ صدور")]
        public string IssueDate { get; set; }

        [Display(Name = "نام موسسه یا آموزشگاه")]
        public string Institute { get; set; }
    }
}
