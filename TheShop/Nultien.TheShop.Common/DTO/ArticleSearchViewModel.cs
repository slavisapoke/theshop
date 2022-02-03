using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.DTO
{
    public class ArticleSearchViewModel
    {
        public int StockId { get; init; }
        public int ArticleID { get; init; } 
        public string ArticleName { get; init; }
        public int Price { get; init; }
        public int SupplierID { get; init; }
        public string SupplierName { get; init; }

        public static ArticleSearchViewModel Create(
            int stockId, 
            int articleId,
            string articleName,
            int price,
            int supplierId,
            string supplierName)
        {
            return new ArticleSearchViewModel
            {
                StockId = stockId,
                ArticleID = articleId,
                ArticleName = articleName,
                Price = price,
                SupplierID = supplierId,
                SupplierName = supplierName
            };
        }
    }
}
