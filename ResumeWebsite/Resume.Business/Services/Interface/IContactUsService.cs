using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IContactUsService
    {
        Task<CreateContactResult> CreateAsync(CreateContactUsViewModel model);
        Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);
        Task<ContactUsDetailsViewModel> GetByID(int id);
        Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model);
    }
}
