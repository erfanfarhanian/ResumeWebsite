using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Skill
{
    public class Skill : BaseEntity<int>
    {
        public string Title { get; set; }
        public Int16 Proficiency { get; set; }
    }
}
