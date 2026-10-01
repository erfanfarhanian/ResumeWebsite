    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Licence
{
    public class LicenceViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string IssueDate { get; set; }
        public string Institute { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
