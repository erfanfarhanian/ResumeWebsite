using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Experience
{
    public class ExperienceViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
