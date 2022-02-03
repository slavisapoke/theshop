using Microsoft.Extensions.Logging;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Nultien.TheShop.Impl.Services
{
    /// <summary>
    /// Shop service implementation
    /// </summary>
    public class ShopService : IShopService
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ShopService> _logger;

        public ShopService(
            IArticleService articleService, 
            ILogger<ShopService> logger)
        {
            this._articleService = articleService;
            this._logger = logger;
        }

        public ArticleViewModel GetById(int id)
        {
            return _articleService.GetById(id);
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> SearchArticles(ArticleSearchParams filter)
        {
            throw new NotImplementedException();
        }
    }
}
