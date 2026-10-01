using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Licence
{
    public class Licence : BaseEntity<int>
    {
        public string Title { get; set; }
        public string IssueDate { get; set; }
        public string Institute { get; set; }
    }
}
