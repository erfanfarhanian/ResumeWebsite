using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Skill
{
    public class SkillViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Int16 Proficiency { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
