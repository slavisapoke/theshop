using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public void Add(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetByArticleInStock(int articleId)
        {
            throw new NotImplementedException();
        }

        public Supplier GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
