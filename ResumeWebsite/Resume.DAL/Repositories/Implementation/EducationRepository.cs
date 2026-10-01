using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Education;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class EducationRepository : IEducationRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public EducationRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<FilterEducationViewModel> FilterEducationAsync(FilterEducationViewModel model)
        {
            var query = _context.Educations.AsQueryable();

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

            await model.Paging(query.Select(e => new EducationViewModel()
            {
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Title = e.Title,
                ID = e.ID,
                CreateDate = e.CreateDate,
                Description = e.Description,
            }));

            #endregion

            return model;
        }

        public async Task<Education> GetEducationByIDAsync(int id)
        {
            return await _context.Educations.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task InsertEducationAsync(Education education)
        {
            await _context.Educations.AddAsync(education);
        }

        public void EditEducationAsync(Education education)
        {
            _context.Educations.Update(education);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<EditEducationViewModel> GetEducationForEditByIDAsync(int id)
        {
            return await _context.Educations.Select(e => new EditEducationViewModel()
            {
                ID = e.ID,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
            }).FirstOrDefaultAsync(e => e.ID == id);
        }

        public void DeleteEducationAsync(Education education)
        {
            _context.Educations.Remove(education);
        }

        public async Task<DeleteEducationViewModel> GetEducationForDeleteByIDAsync(int id)
        {
            return await _context.Educations.Select(e => new DeleteEducationViewModel()
            {
                ID = e.ID,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
            }).FirstOrDefaultAsync(e => e.ID == id);
        }
    }
}
