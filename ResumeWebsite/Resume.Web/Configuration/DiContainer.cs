using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
//using Resume.Bussines.Services.Implementation;
//using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;

namespace Resume.Web.Configuration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services) 
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IAboutMeRepository, AboutMeRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ILicenceRepository, LicenceRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            
            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ILicenceService, LicenceService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<IBlogService, BlogService>();

            // For Sending An Email
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IViewRenderService, ViewRenderService>();

            #endregion
        }
    }
}
