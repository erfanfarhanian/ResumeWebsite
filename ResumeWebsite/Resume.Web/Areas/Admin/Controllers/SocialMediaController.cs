using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.SocialMedia;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SocialMediaController : AdminBaseController
    {
        #region Fields

        private readonly ISocialMediaService _socialMediaService;

        #endregion

        #region Constructor

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterSocialMediaViewModel filter)
        {
            var model = await _socialMediaService.FilterSocialMediaAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _socialMediaService.CreateSocialMediaAsync(model);
            switch (result)
            {
                case CreateSocialMediaResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreateSocialMediaResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _socialMediaService.GetSocialMediaForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditSocialMediaViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _socialMediaService.EditSocialMediaAsync(model);
            switch (result)
            {
                case EditSocialMediaResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditSocialMediaResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditSocialMediaResult.NotFound:
                    TempData[ErrorMessage] = "شبکه اجتماعی یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _socialMediaService.GetSocialMediaForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteSocialMediaViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _socialMediaService.DeleteSocialMediaAsync(model);
            switch (result)
            {
                case DeleteSocialMediaResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteSocialMediaResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeleteSocialMediaResult.NotFound:
                    TempData[ErrorMessage] = "شبکه اجتماعی یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
