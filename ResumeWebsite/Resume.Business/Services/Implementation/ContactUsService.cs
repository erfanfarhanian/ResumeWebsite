using Resume.Business.Services.Interface;
// using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {
        #region Fields

        private readonly IContactUsRepository _contactUsRepository;
        // private readonly IEmailService _emailService;
        // private readonly IViewRenderService _viewRenderService;

        #endregion

        #region Constructor

        public ContactUsService(IContactUsRepository contactUsRepository /*, IEmailService emailService, IViewRenderService viewRenderService*/)
        {
            _contactUsRepository = contactUsRepository;
            // _emailService = emailService;
            // _viewRenderService = viewRenderService;
        }

		#endregion

		#region Methods

		public async Task<CreateContactResult> CreateAsync(CreateContactUsViewModel model)
        {
            ContactUs contactUs = new ContactUs()
            {
                Answer = null,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Title = model.Title,
            };

            await _contactUsRepository.InsertAsync(contactUs);
            await _contactUsRepository.SaveAsync();

            return CreateContactResult.Success;
        }

        public async Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model)
        {
            return await _contactUsRepository.FilterAsync(model);
        }

        public async Task<ContactUsDetailsViewModel> GetByID(int id)
        {
            return await _contactUsRepository.GetInfoByIDAsync(id);
        }

		public async Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model)
		{
			var contactUs = await _contactUsRepository.GetByIDAsync(model.ContactUsID);

            if (contactUs == null) 
            {
                return AnswerResult.ContactUsNotFound;
            }

            if (string.IsNullOrEmpty(model.Answer))
            {
                return AnswerResult.AnswerIsNull;
            }

            contactUs.Answer = model.Answer;

            _contactUsRepository.UpdateAsync(contactUs);
            await _contactUsRepository.SaveAsync();

            // For Sending An Email
            //string body = await _viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
            //await _emailService.SendEmail(contactUs.Email, "پاسخ پیام شما", body);

            return AnswerResult.Success;
		}

		#endregion

	}
}
