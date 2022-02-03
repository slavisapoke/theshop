using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Exceptions.Entity;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nultien.TheShop.Impl.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ShopDbContext _context;

        public ArticleRepository(ShopDbContext context)
        {
            _context = context;
        }
        public Article Add(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();

            return article;
        }

        public Article GetById(int id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.ID == id);

            if(article == null)
            {
                throw new EntityReadException("Cannot find entity", typeof(Article).FullName, id);
            }

            return article;
        } 
    }
}
