using Nultien.TheShop.DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface ISupplierRepository
    {
        /// <summary>
        /// Gets Supplier by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Supplier GetById(int id);

        /// <summary>
        /// Gets all suppliers having the article by the given id
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public IEnumerable<Supplier> GetByArticleInStock(int articleId);

        /// <summary>
        /// Add new supplier
        /// </summary>
        /// <param name="supplier"></param>
        public void Add(Supplier supplier);
    }
}
