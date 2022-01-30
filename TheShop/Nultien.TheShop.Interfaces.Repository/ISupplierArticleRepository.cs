using Nultien.TheShop.Common.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface ISupplierArticleRepository
    {
        /// <summary>
        /// Updates state of the given article for the given supplier
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="supplierId"></param>
        /// <param name="state"></param>
        void UpdateStock(int articleId, int supplierId, ArticleStockState state);
    }
}
