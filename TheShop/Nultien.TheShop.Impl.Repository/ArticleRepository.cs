using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public Article GetById(int id)
        {
            return new Article
            {
                ID = 1, 
                BuyerUserId = null, 
                IsSold = false, 
                Name = "Test Article",
                Price = 1000
            };
        }
    }
}
