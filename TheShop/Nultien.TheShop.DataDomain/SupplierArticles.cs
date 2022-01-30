using Nultien.TheShop.Common.DTO.Enums;

namespace Nultien.TheShop.DataDomain
{
    public class SupplierArticles
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public int ArticleID { get; set; }
        public ArticleStockState State { get; set; }   
    }
}
