using Resume.Business.Generators;
using Resume.Business.Services.Interface;
using Resume.Bussines.Extentions;
using Resume.Bussines.Tools;
using Resume.DAL.Models.Portfolio;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class PortfolioService : IPortfolioService
    {
        #region Fields

        private readonly IPortfolioRepository _portfolioRepository;

        #endregion

        #region Contructor

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        #endregion

        public async Task<CreatePortfolioResult> CreatePortfolioAsync(CreatePortfolioViewModel model)
        {
            if (model.Avatar == null || model.Avatar.Length == 0)
            {
                return CreatePortfolioResult.Error;
            }
            
            //string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName).ToString();
            //model.Avatar.AddImageToServer(imageName, SiteTools.PortfolioAvatar);
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName);
            //string imagePath = Path.Combine(SiteTools.PortfolioAvatar, imageName);
            //Portfolio portfolio2 = new Portfolio();
            model.ImageUrl = imageName;
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Portfolio/", model.ImageUrl);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await model.Avatar.CopyToAsync(stream);
            }

            Portfolio portfolio = new Portfolio()
            {
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                CreateDate = DateTime.Now,
                Description = model.Description,
                ProjectDate = model.ProjectDate,
            };

            await _portfolioRepository.InsertPortfolioAsync(portfolio);
            await _portfolioRepository.SaveChangesAsync();

            return CreatePortfolioResult.Success;
        }

        public async Task<DeletePortfolioResult> DeletePortfolioAsync(DeletePortfolioViewModel model)
        {
            var portfolio = await _portfolioRepository.GetPortfolioByIdAsync(model.ID);
            if (portfolio == null)
            {
                return DeletePortfolioResult.NotFound;
            }

            string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Portfolio/", portfolio.ImageUrl);
            if (File.Exists(deleteImagePath))
            {
                File.Delete(deleteImagePath);
            }

            _portfolioRepository.DeletePortfolioAsync(portfolio);
            await _portfolioRepository.SaveChangesAsync();

            return DeletePortfolioResult.Success;
        }

        public async Task<EditPortfolioResult> EditPortfolioAsync(EditPortfolioViewModel model)
        {
            var portfolio = await _portfolioRepository.GetPortfolioByIdAsync(model.ID);
            if (portfolio == null)
            {
                return EditPortfolioResult.NotFound;
            }

            portfolio.Title = model.Title;
            portfolio.Description = model.Description;
            portfolio.ProjectDate = model.ProjectDate;
            if (model.Avatar != null)
            {
                //string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName).ToString();
                //model.Avatar.AddImageToServer(imageName, SiteTools.PortfolioAvatar);
                string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Portfolio/", portfolio.ImageUrl);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName).ToString();
                portfolio.ImageUrl = imageName;
                //model.Avatar.AddImageToServer(imageName, SiteTools.AboutMeAvatar);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Portfolio/", portfolio.ImageUrl);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await model.Avatar.CopyToAsync(stream);
                }
            }

            _portfolioRepository.EditPortfolioAsync(portfolio);
            await _portfolioRepository.SaveChangesAsync();

            return EditPortfolioResult.Success;
        }

        public async Task<FilterPortfolioViewModel> FilterPortfolioAsync(FilterPortfolioViewModel model)
        {
            return await _portfolioRepository.FilterPortfolioAsync(model);
        }

        public async Task<DeletePortfolioViewModel> GetPortfolioForDeleteByIDAsync(int id)
        {
            return await _portfolioRepository.GetPortfolioForDeleteByIdAsync(id);
        }

        public async Task<EditPortfolioViewModel> GetPortfolioForEditByIDAsync(int id)
        {
            return await _portfolioRepository.GetPortfolioForEditByIdAsync(id);
        }
    }
}
