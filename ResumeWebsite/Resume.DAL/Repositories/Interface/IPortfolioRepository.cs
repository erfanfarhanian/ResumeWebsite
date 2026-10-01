using Resume.DAL.Models.Portfolio;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IPortfolioRepository
    {
        Task<FilterPortfolioViewModel> FilterPortfolioAsync(FilterPortfolioViewModel model);
        Task InsertPortfolioAsync(Portfolio portfolio);
        Task<Portfolio> GetPortfolioByIdAsync(int id);
        void EditPortfolioAsync(Portfolio portfolio);
        void DeletePortfolioAsync(Portfolio portfolio);
        Task<EditPortfolioViewModel> GetPortfolioForEditByIdAsync(int id);
        Task<DeletePortfolioViewModel> GetPortfolioForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
