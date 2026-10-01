using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Activitiy;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public ActivityRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            var query = _context.Activities.AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(a => EF.Functions.Like(a.Title, $"%{model.Title}%"));
            }

            #endregion

            #region OrderBy

            query = query.OrderByDescending(a => a.CreateDate);

            #endregion

            #region Paging

            await model.Paging(query.Select(a => new ActivityDetailsViewModel()
            {
                CreateDate = a.CreateDate,
                Description = a.Description,
                Icon = a.Icon,
                ID = a.ID,
                Title = a.Title
            }));

            #endregion

            return model;
        }

        public async Task<Activity?> GetActivityByIdAsync(int id)
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.ID == id);
        }

		public async Task<List<ActivityDetailsViewModel>> GetAllInfoAsync()
		{
			return await _context.Activities
                .Select(a => new ActivityDetailsViewModel()
            {
                Title = a.Title,
                Description = a.Description,
                Icon = a.Icon,
                ID = a.ID,
                CreateDate = a.CreateDate,
            }).ToListAsync();
		}

		public async Task<EditActvityViewModel?> GetInfoByIDAsync(int id)
        {
            return await _context.Activities.Select(a => new EditActvityViewModel()
            {
                ID = a.ID,
                Title = a.Title,
                Description = a.Description,
                Icon = a.Icon,
            }).FirstOrDefaultAsync(a => a.ID == id);
        }

        public void DeleteAsync(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

        public async Task<DeleteActivityViewModel?> GetInfoByIdForDeleteAsync(int id)
        {
            return await _context.Activities.Select(a => new DeleteActivityViewModel()
            {
                ID = a.ID,
                Title = a.Title,
                Description = a.Description,
                Icon = a.Icon,
            }).FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task InsertAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Activity activity)
        {
            _context.Activities.Update(activity);
        }

        #endregion

    }
}
