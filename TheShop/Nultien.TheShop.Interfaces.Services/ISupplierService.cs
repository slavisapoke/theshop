using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Services
{
    public interface ISupplierService
    {
        /// <summary>
        /// Gets Supplier by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierViewModel GetById(int id);

        /// <summary>
        /// Gets all suppliers having the article by the given id
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public IEnumerable<SupplierViewModel> GetByArticleInStock(int articleId);

        /// <summary>
        /// Add new supplier
        /// </summary>
        /// <param name="supplier"></param>
        public void Add(SupplierViewModel supplier);

        /// <summary>
        /// Updates article state for the given supplier
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="supplierId"></param>
        /// <param name="state"></param>
        void UpdateStock(int articleId, int supplierId, ArticleStockState state);
    }
}
