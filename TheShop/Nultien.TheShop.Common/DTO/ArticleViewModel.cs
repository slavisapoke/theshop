using System;

namespace Nultien.TheShop.Common.DTO
{
    public class ArticleViewModel
	{
		public int ID { get; init; }      
		public string Name_of_article { get; init; }
		public int ArticlePrice { get; init; }
		public bool IsSold { get; init; }
		public DateTime? SoldDate { get; init; }
		public int? BuyerUserId { get; init; }
	}
}
