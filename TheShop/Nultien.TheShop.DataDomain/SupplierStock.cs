using Nultien.TheShop.Common.DTO.Enums;
using System.Collections.Generic;

namespace Nultien.TheShop.DataDomain
{
    public class SupplierStock : DbEntity
    {
        public int SupplierID { get; set; }
        public int ArticleID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Supplier Supplier { get; set; }
        public Article Article { get; set; }
    }
}
