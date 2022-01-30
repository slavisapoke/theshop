﻿using System;

namespace Nultien.TheShop.DataDomain
{
    public class Article
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public bool IsSold { get; set; }
		public DateTime SoldDate { get; set; }
		public int? BuyerUserId { get; set; }
	}
}
