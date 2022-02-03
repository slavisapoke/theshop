using System.Collections.Generic;

namespace Nultien.TheShop.DataDomain
{
    public class Supplier : DbEntity
    {
        public string Name { get; set; }
        public ICollection<SupplierStock> SupplierStocks { get; set; }
    }
}
