using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Portfolio;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioController : AdminBaseController
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

        #region List

        public async Task<IActionResult> List(FilterPortfolioViewModel filter)
        {
            var model = await _portfolioService.FilterPortfolioAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _portfolioService.CreatePortfolioAsync(model);
            switch (result)
            {
                case CreatePortfolioResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreatePortfolioResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _portfolioService.GetPortfolioForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditPortfolioViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _portfolioService.EditPortfolioAsync(model);
            switch (result)
            {
                case EditPortfolioResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditPortfolioResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditPortfolioResult.NotFound:
                    TempData[ErrorMessage] = "نمونه کار یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _portfolioService.GetPortfolioForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePortfolioViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _portfolioService.DeletePortfolioAsync(model);
            switch (result)
            {
                case DeletePortfolioResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeletePortfolioResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeletePortfolioResult.NotFound:
                    TempData[ErrorMessage] = "نمونه کار مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
