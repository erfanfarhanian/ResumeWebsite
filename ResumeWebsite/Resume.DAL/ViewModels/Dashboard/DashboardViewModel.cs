using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int ProjectsCount { get; set; }
        public int CommentsCount { get; set; }
        public int ContactUsCount { get; set; }
        public int BlogCount { get; set; }
    }
}
