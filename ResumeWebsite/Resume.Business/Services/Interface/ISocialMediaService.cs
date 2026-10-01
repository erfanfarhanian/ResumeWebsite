using Resume.DAL.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface ISocialMediaService
    {
        Task<FilterSocialMediaViewModel> FilterSocialMediaAsync(FilterSocialMediaViewModel model);
        Task<CreateSocialMediaResult> CreateSocialMediaAsync(CreateSocialMediaViewModel model);
        Task<EditSocialMediaResult> EditSocialMediaAsync(EditSocialMediaViewModel model);
        Task<DeleteSocialMediaResult> DeleteSocialMediaAsync(DeleteSocialMediaViewModel model);
        Task<EditSocialMediaViewModel> GetSocialMediaForEditByIDAsync(int id);
        Task<DeleteSocialMediaViewModel> GetSocialMediaForDeleteByIDAsync(int id);
    }
}
