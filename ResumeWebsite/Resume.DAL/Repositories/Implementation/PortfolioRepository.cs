using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Portfolio;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class PortfolioRepository : IPortfolioRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public PortfolioRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void DeletePortfolioAsync(Portfolio portfolio)
        {
            _context.Portfolios.Remove(portfolio);
        }

        public void EditPortfolioAsync(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
        }

        public async Task<FilterPortfolioViewModel> FilterPortfolioAsync(FilterPortfolioViewModel model)
        {
            var query = _context.Portfolios.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(p => p.Title.Contains(model.Title));
            }

            if (!string.IsNullOrEmpty(model.ProjectDate))
            {
                query = query.Where(p => p.ProjectDate.Contains(model.ProjectDate));
            }

            #endregion

            query = query.OrderByDescending(p => p.CreateDate);

            #region Pagination

            await model.Paging(query.Select(p => new PortfolioViewModel()
            {
                ID = p.ID,
                Title = p.Title,
                ProjectDate = p.ProjectDate,
                CreateDate = p.CreateDate,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            }));

            #endregion

            return model;
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int id)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<DeletePortfolioViewModel> GetPortfolioForDeleteByIdAsync(int id)
        {
            return await _context.Portfolios.Select(p => new DeletePortfolioViewModel()
            {
                ID = p.ID,
                Title = p.Title,
                ProjectDate = p.ProjectDate,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            }).FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<EditPortfolioViewModel> GetPortfolioForEditByIdAsync(int id)
        {
            return await _context.Portfolios.Select(p => new EditPortfolioViewModel()
            {
                ID = p.ID,
                Title = p.Title,
                ProjectDate = p.ProjectDate,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            }).FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task InsertPortfolioAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
