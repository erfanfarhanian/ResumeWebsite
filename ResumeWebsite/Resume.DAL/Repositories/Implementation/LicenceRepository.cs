using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Experience;
using Resume.DAL.Models.Licence;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class LicenceRepository : ILicenceRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public LicenceRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void EditLicenceAsync(Licence licence)
        {
            _context.Licences.Update(licence);
        }

        public void DeleteLicenceAsync(Licence licence)
        {
            _context.Licences.Remove(licence);
        }

        public async Task<FilterLicenceViewModel> FilterLicenceAsync(FilterLicenceViewModel model)
        {
            var query = _context.Licences.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(l => l.Title.Contains(model.Title));
            }

            if (!string.IsNullOrEmpty(model.IssueDate))
            {
                query = query.Where(l => l.IssueDate.Contains(model.IssueDate));
            }

            if (!string.IsNullOrEmpty(model.Institute))
            {
                query = query.Where(l => l.Institute.Contains(model.Institute));
            }

            #endregion

            query = query.OrderByDescending(l => l.CreateDate);

            #region Pagination

            await model.Paging(query.Select(l => new LicenceViewModel()
            {
                ID = l.ID,
                Title = l.Title,
                Institute = l.Institute,
                CreateDate = l.CreateDate,
                IssueDate = l.IssueDate
            }));

            #endregion

            return model;
        }

        public async Task<Licence> GetLicenceByIdAsync(int id)
        {
            return await _context.Licences.FirstOrDefaultAsync(l => l.ID == id);
        }

        public async Task<DeleteLicenceViewModel> GetLicenceForDeleteByIdAsync(int id)
        {
            return await _context.Licences.Select(l => new DeleteLicenceViewModel()
            {
                ID = l.ID,
                Title = l.Title,
                IssueDate = l.IssueDate,
                Institute = l.Institute
            }).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<EditLicenceViewModel> GetLicenceForEditByIdAsync(int id)
        {
            return await _context.Licences.Select(l => new EditLicenceViewModel()
            {
                ID = l.ID,
                Title = l.Title,
                IssueDate = l.IssueDate,
                Institute = l.Institute
            }).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task InsertLicenceAsync(Licence licence)
        {
            await _context.Licences.AddAsync(licence);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
