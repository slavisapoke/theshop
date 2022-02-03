using Microsoft.Extensions.Logging;
using Nultien.TheShop.Common.Exceptions.Entity;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
using System.Linq;

namespace Nultien.TheShop.Impl.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopDbContext _context;
        private readonly ILogger<SupplierRepository> _logger;

        public SupplierRepository(ShopDbContext context,
            ILogger<SupplierRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Supplier Add(Supplier supplier)
        {
            //If business doesn't allow two suppliers with the same name, validate
            var supplierExists = _context.Suppliers.Any(s => s.Name.ToLowerInvariant() == supplier.Name.ToLowerInvariant());
            if (supplierExists)
            {
                var message = $"Supplier cannot be added. Supplier name {supplier.Name} is not unique.";
                _logger.LogError(message);
                throw new EntityAddException(message, typeof(Supplier).FullName);    
            }

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return supplier;
        }

        public Supplier GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.ID == id);
        }
    }
}
