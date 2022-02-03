using Microsoft.Extensions.Logging;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Exceptions.Entity;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Nultien.TheShop.Impl.Repository
{
    public class SupplierArticleRepository : ISupplierArticleRepository
    {
        private readonly ShopDbContext _context;
        private readonly ILogger<SupplierArticleRepository> _logger;

        public SupplierArticleRepository(
            ShopDbContext context,
            ILogger<SupplierArticleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public SupplierStock Get(int articleId, int supplierId)
        {
            return _context.SupplierStocks.FirstOrDefault(s => s.ArticleID == articleId && s.SupplierID == supplierId);
        }

        public void Delete(int stockId)
        {
            var stock = _context.SupplierStocks.FirstOrDefault(s => s.ID == stockId);
            if (stock == null)
            {
                _logger.LogError($"Cannot find article stocks for deletion with id: {stockId}");
                throw new EntityDeleteException("Cannot find article stocks for deletion", typeof(SupplierStock).FullName, stockId);
            }

            _context.SupplierStocks.Remove(stock);
            _context.SaveChanges();
        }

        public SupplierStock Upsert(SupplierStock stock)
        {
            var existingStock = _context.SupplierStocks.FirstOrDefault(s =>
                (stock.ID > 0 && s.ID == stock.ID) ||
                (s.ArticleID == stock.ArticleID && s.SupplierID == stock.SupplierID));

            if (existingStock == null)
            {
                existingStock = new SupplierStock
                {
                    ArticleID = stock.ArticleID,
                    SupplierID = stock.SupplierID,
                    Price = stock.Price,
                    Quantity = stock.Quantity
                };
                _context.SupplierStocks.Add(existingStock);
            }
            else
            {
                existingStock.Price = stock.Price;
                existingStock.Quantity = stock.Quantity;
                _context.MarkChanged(existingStock);
            }

            _context.SaveChanges();

            return existingStock;
        }

        public IEnumerable<ArticleSearchViewModel> Search(
            string name,
            int maxPrice,
            int minPrice,
            int pageIndex,
            int pageSize)
        {
            var result = from s in _context.SupplierStocks
                         where
                            (string.IsNullOrEmpty(name) ||
                                s.Article.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())) &&
                            (maxPrice <= 0 || s.Price <= maxPrice) &&
                            (minPrice <= 0 || s.Price >= minPrice)
                         select ArticleSearchViewModel.Create(
                             s.ID,
                             s.ArticleID, 
                             s.Article.Name,
                             s.Price,
                             s.SupplierID, 
                             s.Supplier.Name);

            return result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
