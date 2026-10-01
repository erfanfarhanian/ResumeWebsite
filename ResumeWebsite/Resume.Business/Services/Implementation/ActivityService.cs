using Resume.Business.Services.Interface;
using Resume.DAL.Models.Activitiy;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        #region Fields

        private readonly IActivityRepository _activityRepository;

        #endregion

        #region Contructor

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        #endregion

        public async Task<CreateActivityResult> CreateAsync(CreateActvityViewModel model)
        {
            Activity activity = new Activity()
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                Icon = model.Icon,
                Title = model.Title
            };

            await _activityRepository.InsertAsync(activity);
            await _activityRepository.SaveAsync();

            return CreateActivityResult.Success;
        }

        public async Task<DeleteActivityResult> DeleteAsync(DeleteActivityViewModel model)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(model.ID);

            if (activity == null)
            {
                return DeleteActivityResult.NotFound;
            }

            //activity.Description = model.Description;
            //activity.Icon = model.Icon;
            //activity.Title = model.Title;

            _activityRepository.DeleteAsync(activity);
            await _activityRepository.SaveAsync();

            return DeleteActivityResult.Success;
        }

        public Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            return _activityRepository.FilterAsync(model);
        }

        public async Task<List<ActivityDetailsViewModel>> GetAllInfoAsync()
        {
            return await _activityRepository.GetAllInfoAsync();
        }

        public async Task<EditActvityViewModel?> GetInfoByIDAsync(int id)
        {
            return await _activityRepository.GetInfoByIDAsync(id);
        }

        public async Task<DeleteActivityViewModel?> GetInfoByIdForDeleteAsync(int id)
        {
            return await _activityRepository.GetInfoByIdForDeleteAsync(id);
        }

        public async Task<EditActivityResult> UpdateAsync(EditActvityViewModel model)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(model.ID);

            if (activity == null)
            {
                return EditActivityResult.NotFound;
            }

            activity.Description = model.Description;
            activity.Icon = model.Icon;
            activity.Title = model.Title;

            _activityRepository.UpdateAsync(activity);
            await _activityRepository.SaveAsync();

            return EditActivityResult.Success;
        }
    }
}
