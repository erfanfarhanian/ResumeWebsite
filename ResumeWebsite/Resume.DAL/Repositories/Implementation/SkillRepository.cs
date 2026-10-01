using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Licence;
using Resume.DAL.Models.Skill;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Licence;
using Resume.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class SkillRepository : ISkillRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public SkillRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void EditSkillAsync(Skill skill)
        {
            _context.Skills.Update(skill);
        }

        public async Task<FilterSkillViewModel> FilterSkillAsync(FilterSkillViewModel model)
        {
            var query = _context.Skills.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(s => s.Title.Contains(model.Title));
            }

            #endregion

            query = query.OrderByDescending(s => s.CreateDate);

            #region Pagination

            await model.Paging(query.Select(s => new SkillViewModel()
            {
                ID = s.ID,
                Title = s.Title,
                Proficiency = s.Proficiency,
                CreateDate = s.CreateDate
            }));

            #endregion

            return model;
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<EditSkillViewModel> GetSkillForEditByIdAsync(int id)
        {
            return await _context.Skills.Select(s => new EditSkillViewModel()
            {
                ID = s.ID,
                Title = s.Title,
                Proficiency = s.Proficiency
            }).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task InsertSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public void DeleteSkillAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<DeleteSkillViewModel> GetSkillForDeleteByIdAsync(int id)
        {
            return await _context.Skills.Select(s => new DeleteSkillViewModel()
            {
                ID = s.ID,
                Title = s.Title,
                Proficiency = s.Proficiency
            }).FirstOrDefaultAsync(s => s.ID == id);
        }
    }
}
