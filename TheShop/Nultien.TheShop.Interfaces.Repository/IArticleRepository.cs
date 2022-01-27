using Nultien.TheShop.DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface IArticleRepository
    {
        Article GetById(int id);
    }
}
