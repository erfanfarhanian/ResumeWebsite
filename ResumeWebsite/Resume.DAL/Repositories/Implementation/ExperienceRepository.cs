using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Education;
using Resume.DAL.Models.Experience;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Education;
using Resume.DAL.ViewModels.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ExperienceRepository : IExperienceRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public ExperienceRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void EditExperienceAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
        }

        public void DeleteExperienceAsync(Experience experience)
        {
            _context.Experiences.Remove(experience);
        }

        public async Task<FilterExperienceViewModel> FilterExperienceAsync(FilterExperienceViewModel model)
        {
            var query = _context.Experiences.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(e => e.Title.Contains(model.Title));
            }

            if (model.StartDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= model.StartDate.Value);
            }

            if (model.EndDate.HasValue)
            {
                query = query.Where(e => e.EndDate <= model.EndDate.Value);
            }

            #endregion

            query = query.OrderByDescending(e => e.CreateDate);

            #region Pagination

            await model.Paging(query.Select(e => new ExperienceViewModel()
            {
                ID = e.ID,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateDate = e.CreateDate,
                Description = e.Description
            }));

            #endregion

            return model;
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<DeleteExperienceViewModel> GetExperienceForDeleteByIdAsync(int id)
        {
            return await _context.Experiences.Select(e => new DeleteExperienceViewModel()
            {
                ID = e.ID,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
            }).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<EditExperienceViewModel> GetExperienceForEditByIdAsync(int id)
        {
            return await _context.Experiences.Select(e => new EditExperienceViewModel()
            {
                ID = e.ID,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
            }).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task InsertExperienceAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
