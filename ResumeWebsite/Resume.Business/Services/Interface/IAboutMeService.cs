using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IAboutMeService
    {
        #region Admin

        Task<AdminSideEditAboutMeViewModel?> GetInfoAsync();
        Task<AdminSiteEditAboutMeResult> UpdateAsync(AdminSideEditAboutMeViewModel model);

        #endregion

        #region Client

        Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync();

        #endregion
    }
}
