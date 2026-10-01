using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public ContactUsRepository(ResumeContext Context)
        {
            _context = Context;
        }

        #endregion

        #region Methods

        public async Task InsertAsync(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model)
        {
            var query = _context.ContactUs.AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.FirstName))
            {
				//query.Where(contactUs => EF.Functions.Like(contactUs.FirstName, $"%{model.FirstName}%"));
				query = query.Where(p => p.FirstName.Contains(model.FirstName));
			}

            if (!string.IsNullOrEmpty(model.LastName))
            {
				//query.Where(contactUs => EF.Functions.Like(contactUs.LastName, $"%{model.LastName}%"));
				query = query.Where(p => p.LastName.Contains(model.LastName));
			}

            if (!string.IsNullOrEmpty(model.Email))
            {
				//query.Where(contactUs => EF.Functions.Like(contactUs.Email, $"%{model.Email}%"));
				query = query.Where(p => p.Email.Contains(model.Email));
			}

            if (!string.IsNullOrEmpty(model.Mobile))
            {
				//query.Where(contactUs => EF.Functions.Like(contactUs.Mobile, $"%{model.Mobile}%"));
				query = query.Where(p => p.Mobile.Contains(model.Mobile));
			}

            if (!string.IsNullOrEmpty(model.Title))
            {
				//query.Where(contactUs => EF.Functions.Like(contactUs.Title, $"%{model.Title}%"));
				query = query.Where(p => p.Title.Contains(model.Title));
			}

            switch (model.AnswerStatus)
            {
                case FilterContactUsAnswerStatus.All:
                    break;
                case FilterContactUsAnswerStatus.Answered:
                    query = query.Where(contactUs => contactUs.Answer != null);
                    break;
                case FilterContactUsAnswerStatus.NotAnswered:
                    query = query.Where(contactUs => contactUs.Answer == null);
                    break;
            }

            #endregion

            query = query.OrderByDescending(contactUs => contactUs.CreateDate);

            #region Pagination

            await model.Paging(query.Select(contactUs => new ContactUsDetailsViewModel()
            {
                Answer = contactUs.Answer,
                Email = contactUs.Email,
                Mobile = contactUs.Mobile,
                Title = contactUs.Title,
                Description = contactUs.Description,
                ContactUsID = contactUs.ID,
                FirstName = contactUs.FirstName,
                LastName = contactUs.LastName,
                CreateDate = contactUs.CreateDate
            }));

            #endregion

            return model;
        }

        public async Task<ContactUsDetailsViewModel> GetInfoByIDAsync(int id)
        {
            return await _context.ContactUs.Select(contactUs => new ContactUsDetailsViewModel()
            {
                ContactUsID = contactUs.ID,
                FirstName = contactUs.FirstName,
                LastName = contactUs.LastName,
                Description = contactUs.Description,
                Email = contactUs.Email,
                Mobile = contactUs.Mobile,
                CreateDate = contactUs.CreateDate,
                Title = contactUs.Title,
                Answer = contactUs.Answer
            }).FirstOrDefaultAsync(contactUs => contactUs.ContactUsID == id);

        }

		public async Task<ContactUs> GetByIDAsync(int id)
		{
			return await _context.ContactUs.FirstOrDefaultAsync(contactUs => contactUs.ID == id);
		}

		public async void UpdateAsync(ContactUs contactUs)
		{
			_context.ContactUs.Update(contactUs);
		}

		#endregion

	}
}
