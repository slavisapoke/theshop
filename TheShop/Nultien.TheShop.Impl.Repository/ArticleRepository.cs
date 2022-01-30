using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Nultien.TheShop.Impl.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public Article Add(Article article)
        {
            throw new NotImplementedException();
        }

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

        public List<Article> Search(ArticleSearchParams filter)
        {
            throw new NotImplementedException();
        }
    }
}
