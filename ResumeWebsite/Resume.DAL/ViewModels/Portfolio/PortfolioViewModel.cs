using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Portfolio
{
    public class PortfolioViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string? ProjectDate { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
