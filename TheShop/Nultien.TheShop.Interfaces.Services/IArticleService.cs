using Nultien.TheShop.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Services
{
    public interface IArticleService
    {
        ArticleViewModel GetById(int id);
    }
}
