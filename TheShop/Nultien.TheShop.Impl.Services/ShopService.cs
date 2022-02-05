using Microsoft.Extensions.Logging;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Exceptions;
using Nultien.TheShop.Interfaces.Repository;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Nultien.TheShop.Common.Extensions;

namespace Nultien.TheShop.Impl.Services
{
    /// <summary>
    /// Shop service implementation
    /// </summary>
    public class ShopService : IShopService
    {
        private readonly IArticleService _articleService;
        private readonly ISupplierArticleRepository _suplierArticleRepo;
        private readonly ILogger<ShopService> _logger;

        public ShopService(
            IArticleService articleService,
            ISupplierArticleRepository suplierArticleRepo,
            ILogger<ShopService> logger)
        {
            _articleService = articleService;
            _logger = logger;
            _suplierArticleRepo = suplierArticleRepo;
        }

        public ArticleViewModel GetById(int id)
        {
            return _articleService.GetById(id);
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            var articlesInStock = _suplierArticleRepo.Search(id, null, maxExpectedPrice, 0, true, 0, 1);

            if (articlesInStock.NullOrEmpty())
            {
                throw new OrderException(id, Common.Enums.OrderStateEnum.ArticleNotInStock);
            }

            var stockEntry = articlesInStock.First();

            var stock = _suplierArticleRepo.Get(stockEntry.ArticleID, stockEntry.SupplierID);

            stock.Quantity--;

            _suplierArticleRepo.Upsert(stock);
        }
    }
}
