using Nultien.TheShop.Common.DTO.Enums;
using Nultien.TheShop.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Repository
{
    public class SupplierArticleRepository : ISupplierArticleRepository
    {
        public void UpdateStock(int articleId, int supplierId, ArticleStockState state)
        {
            throw new NotImplementedException();
        }
    }
}
