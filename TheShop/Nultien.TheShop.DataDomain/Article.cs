using System;
using System.Collections.Generic;

namespace Nultien.TheShop.DataDomain
{
    public class Article : DbEntity
	{
		public string EAN { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public bool IsSold { get; set; }
		public DateTime? SoldDate { get; set; }
		public int? BuyerUserId { get; set; }
		public ICollection<SupplierStock>  SupplierStocks { get; set; }
	}
}
