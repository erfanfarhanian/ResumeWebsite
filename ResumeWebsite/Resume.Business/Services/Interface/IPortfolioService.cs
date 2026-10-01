using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IPortfolioService
    {
        Task<FilterPortfolioViewModel> FilterPortfolioAsync(FilterPortfolioViewModel model);
        Task<CreatePortfolioResult> CreatePortfolioAsync(CreatePortfolioViewModel model);
        Task<EditPortfolioResult> EditPortfolioAsync(EditPortfolioViewModel model);
        Task<DeletePortfolioResult> DeletePortfolioAsync(DeletePortfolioViewModel model);
        Task<EditPortfolioViewModel> GetPortfolioForEditByIDAsync(int id);
        Task<DeletePortfolioViewModel> GetPortfolioForDeleteByIDAsync(int id);
    }
}
