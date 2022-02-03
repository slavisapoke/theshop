using Nultien.TheShop.Common.DTO;
using System.Collections.Generic;

namespace Nultien.TheShop.Interfaces.Services
{
    public interface IArticleService
    {
        ArticleViewModel GetById(int id);
        int Add(ArticleViewModel article);
    }
}
