using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class AboutMeRepository : IAboutMeRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public AboutMeRepository(ResumeContext context)
        {
            _context = context;
        }

        

        #endregion

        #region Methods

        public async Task<AdminSideEditAboutMeViewModel?> GetInfoAsync()
        {
            return await _context.AboutMe.Select(aboutMe => new AdminSideEditAboutMeViewModel()
            {
                ID = aboutMe.ID,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Email = aboutMe.Email,
                Mobile = aboutMe.Mobile,
                Location = aboutMe.Location,
                BirthDate = aboutMe.BirthDate,
                Position = aboutMe.Position,
                Bio = aboutMe.Bio,
                ImageName = aboutMe.ImageName,
            }).FirstOrDefaultAsync();
        }

        public async Task<AboutMe?> GetAsync()
        {
            return await _context.AboutMe.FirstOrDefaultAsync();
        }

        public void Update(AboutMe aboutMe)
        {
            _context.AboutMe.Update(aboutMe);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync()
        {
            return await _context.AboutMe.Select(aboutMe => new ClientSideEditAboutMeViewModel  ()
            {
                ID = aboutMe.ID,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Email = aboutMe.Email,
                Mobile = aboutMe.Mobile,
                Location = aboutMe.Location,
                BirthDate = aboutMe.BirthDate,
                Position = aboutMe.Position,
                Bio = aboutMe.Bio,
                ImageName = aboutMe.ImageName,
            }).FirstOrDefaultAsync();
        }

        #endregion

    }
}
