using AutoMapper;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Helpers;
using Nultien.TheShop.Interfaces.Repository;
using Nultien.TheShop.Interfaces.Services;
using System.Collections.Generic;

namespace Nultien.TheShop.Impl.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IMapper mapper, 
            IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public ArticleViewModel Add(ArticleViewModel article)
        {
            Validation.Create()
                .NotNullOrEmpty(article, "Article should not be null")
                .IsTrue(article.ID == 0, "Article ID should be zero")
                .NotNullOrEmpty(article.Name_of_article, "Article name should not be null or empty");

            throw new System.NotImplementedException();
        }

        public ArticleViewModel GetById(int id)
        {
            Validation.Create()
                .IsGreaterThan(id, 0, "Id should be greater than zero");

            var article = _articleRepository.GetById(id);

            return _mapper.Map<ArticleViewModel>(article);
        }

        public List<ArticleViewModel> Search(ArticleSearchParams filter)
        {
            Validation.Create()
                .NotNullOrDefault(filter, "Filter should not be null")
                .IsTrue(() => filter.MaxPrice >= filter.MinPrice, "Max price should be greater or equal than min price");

            throw new System.NotImplementedException();
        }
    }
}
