using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;
using Resume.DAL.ViewModels.Skill;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class LicenceController : AdminBaseController
    {
        #region Fields

        private readonly ILicenceService _licenceService;

        #endregion

        #region Constructor

        public LicenceController(ILicenceService licenceService)
        {
            _licenceService = licenceService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterLicenceViewModel filter)
        {
            var model = await _licenceService.FilterLicenceAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLicenceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _licenceService.CreateLicenceAsync(model);
            switch (result)
            {
                case CreateLicenceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreateLicenceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _licenceService.GetLicenceForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditLicenceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _licenceService.EditLicenceAsync(model);
            switch (result)
            {
                case EditLicenceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditLicenceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditLicenceResult.NotFound:
                    TempData[ErrorMessage] = "گواهینامه یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _licenceService.GetLicenceForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteLicenceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _licenceService.DeleteLicenceAsync(model);
            switch (result)
            {
                case DeleteLicenceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteLicenceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeleteLicenceResult.NotFound:
                    TempData[ErrorMessage] = "مهارت مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
