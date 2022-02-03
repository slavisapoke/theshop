using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.DataDomain;
using System.Collections.Generic;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface ISupplierArticleRepository
    {
        /// <summary>
        /// Update/insert supplier stocks for the given article
        /// </summary>
        /// <param name="stock"></param> 
        SupplierStock Upsert(SupplierStock stock);

        /// <summary>
        /// Gets stock for article for the supplier
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        SupplierStock Get(int articleId, int supplierId);

        /// <summary>
        /// Deletes stock record by the given id
        /// </summary>
        /// <param name="stockId"></param>
        void Delete(int stockId);

        /// <summary>
        /// Searches for articles in supplier stocks by the given parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<ArticleSearchViewModel> Search( 
            string name, 
            int maxPrice,
            int minPrice,
            int pageIndex,
            int pageSize);
    }
}
