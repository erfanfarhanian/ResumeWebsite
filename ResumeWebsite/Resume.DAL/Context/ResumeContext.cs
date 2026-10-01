using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Models.Activitiy;
using Resume.DAL.Models.Blog;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Models.Education;
using Resume.DAL.Models.Experience;
using Resume.DAL.Models.Licence;
using Resume.DAL.Models.Portfolio;
using Resume.DAL.Models.Skill;
using Resume.DAL.Models.SocialMedia;
using Resume.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Context
{
    public class ResumeContext : DbContext
    {
        #region Constructor

        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {

        }

        #endregion

        #region DBSet

        public DbSet<User> Users { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<AboutMe> AboutMe { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Licence> Licences { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data

            #region User

            modelBuilder.Entity<User>().HasData(new User()
            {
                CreateDate = DateTime.Now,
                Email = "erfanfarhanian@gmail.com",
                FirstName = "عرفان",
                LastName = "فرهانیان",
                ID = 1,
                IsActive = true,
                Mobile = "09045771077",
                Password = "BE-F9-16-6A-72-16-A8-12-5D-7A-89-06-C4-02-8C-C4"
            });

            #endregion

            #region AboutMe

            modelBuilder.Entity<AboutMe>().HasData(new AboutMe()
            {
                Email = "",
                Bio = "",
                FirstName = "",
                LastName = "",
                Mobile = "",
                Location = "",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                CreateDate = DateTime.Now,
                ID = 1,
                Position = "",
                ImageName = ""
            });

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
