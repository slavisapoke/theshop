using Nultien.TheShop.DataDomain;

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
        /// Add new supplier
        /// </summary>
        /// <param name="supplier"></param>
        public Supplier Add(Supplier supplier);
    }
}
