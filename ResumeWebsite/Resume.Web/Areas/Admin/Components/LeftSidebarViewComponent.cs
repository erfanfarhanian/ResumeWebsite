using Microsoft.AspNetCore.Mvc;
using Resume.Business.Extensions;
using Resume.Business.Services.Interface;

namespace Resume.Web.Areas.Admin.Components
{
    public class LeftSidebarViewComponent : ViewComponent
    {
		#region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public LeftSidebarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["User"] = await _userService.GetInformationAsync(User.GetUserID());

            return View("LeftSidebar");
        }

        #endregion
    }
}
