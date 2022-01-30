using System;

namespace Nultien.TheShop.Common.DTO
{
    public class ArticleViewModel
	{
		public int ID { get; set; }
		public string Name_of_article { get; set; }
		public int ArticlePrice { get; set; }
		public bool IsSold { get; set; }
		public DateTime SoldDate { get; set; }
		public int? BuyerUserId { get; set; }
	}
}
