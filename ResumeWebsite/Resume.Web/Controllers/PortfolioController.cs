using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Experience;

namespace Resume.Web.Controllers
{
    public class PortfolioController : SiteBaseController
    {
        #region Fields

        private readonly IPortfolioService _portfolioService;

        #endregion

        #region Constructor

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion

        #region Actions

        #region Index

        public async Task<IActionResult> Index()
        {
            var model = await _portfolioService.FilterPortfolioAsync(new DAL.ViewModels.Portfolio.FilterPortfolioViewModel()
            {
            });

            return View(model);
        }

        #endregion

        #region Show

        public async Task<IActionResult> ShowPortfolio(int id)
        {
            var model = await _portfolioService.GetPortfolioForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
