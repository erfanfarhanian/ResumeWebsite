using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers
{
    public class ResumeController : SiteBaseController
    {
        #region Actions

        [HttpGet("/resume")]
        public IActionResult Index()
        { 
            return View(); 
        }

        #endregion
    }
}
