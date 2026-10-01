using Resume.DAL.Models.Experience;
using Resume.DAL.Models.SocialMedia;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface ISocialMediaRepository
    {
        Task<FilterSocialMediaViewModel> FilterSocialMediaAsync(FilterSocialMediaViewModel model);
        Task InsertSocialMediaAsync(SocialMedia socialMedia);
        Task<SocialMedia> GetSocialMediaByIdAsync(int id);
        void EditSocialMediaAsync(SocialMedia socialMedia);
        void DeleteSocialMediaAsync(SocialMedia socialMedia);
        Task<EditSocialMediaViewModel> GetSocialMediaForEditByIdAsync(int id);
        Task<DeleteSocialMediaViewModel> GetSocialMediaForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
