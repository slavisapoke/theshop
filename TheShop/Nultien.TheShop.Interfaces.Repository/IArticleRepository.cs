using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.DataDomain;
using System.Collections.Generic;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface IArticleRepository
    {
        Article GetById(int id);
        Article Add(Article article);
        List<Article> Search(ArticleSearchParams filter);
    }
}
