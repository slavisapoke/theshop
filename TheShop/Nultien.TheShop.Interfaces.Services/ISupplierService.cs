using Nultien.TheShop.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Services
{
    public interface ISupplierService
    {
        /// <summary>
        /// Gets Supplier by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierViewModel GetById(int id);

        /// <summary>
        /// Add new supplier
        /// </summary>
        /// <param name="supplier"></param>
        public int Add(SupplierViewModel supplier); 
    }
}
