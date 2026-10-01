using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Experience;
using Resume.DAL.Models.SocialMedia;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public SocialMediaRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void DeleteSocialMediaAsync(SocialMedia socialMedia)
        {
            _context.SocialMedias.Remove(socialMedia);
        }

        public void EditSocialMediaAsync(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
        }

        public async Task<FilterSocialMediaViewModel> FilterSocialMediaAsync(FilterSocialMediaViewModel model)
        {
            var query = _context.SocialMedias.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(s => s.Title.Contains(model.Title));
            }

            #endregion

            query = query.OrderByDescending(s => s.CreateDate);

            #region Pagination

            await model.Paging(query.Select(s => new SocialMediaViewModel()
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                CreateDate = s.CreateDate,
                Icon = s.Icon
            }));

            #endregion

            return model;
        }

        public async Task<SocialMedia> GetSocialMediaByIdAsync(int id)
        {
            return await _context.SocialMedias.FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<DeleteSocialMediaViewModel> GetSocialMediaForDeleteByIdAsync(int id)
        {
            return await _context.SocialMedias.Select(s => new DeleteSocialMediaViewModel()
            {
                ID= s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon
            }).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<EditSocialMediaViewModel> GetSocialMediaForEditByIdAsync(int id)
        {
            return await _context.SocialMedias.Select(s => new EditSocialMediaViewModel()
            {
                ID = s.ID,
                Title = s.Title,
                Icon = s.Icon,
                Url = s.Url
            }).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task InsertSocialMediaAsync(SocialMedia socialMedia)
        {
            await _context.SocialMedias.AddAsync(socialMedia);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
