using Resume.DAL.Models.ContactUs;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IContactUsRepository
    {
        Task InsertAsync(ContactUs contactUs);
        Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);
        Task<ContactUsDetailsViewModel> GetInfoByIDAsync(int id);
        Task<ContactUs> GetByIDAsync(int id);
        void UpdateAsync(ContactUs contactUs);
        Task SaveAsync();
    }
}
