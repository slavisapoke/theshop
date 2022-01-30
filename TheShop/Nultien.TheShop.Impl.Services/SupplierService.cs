using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.DTO.Enums;
using Nultien.TheShop.Common.Helpers;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Services
{
    public class SupplierService : ISupplierService
    {
        public void Add(SupplierViewModel supplier)
        {
            Validation.Create()
                   .NotNullOrEmpty(supplier, "Supplier should not be null")
                   .IsTrue(supplier.ID == 0, "Supplier ID should be zero")
                   .NotNullOrEmpty(supplier.Name, "Supplier name should not be null or empty");

            throw new NotImplementedException();
        }

        public IEnumerable<SupplierViewModel> GetByArticleInStock(int articleId)
        {
            Validation.Create()
                .IsGreaterThan(articleId, 0, "Article ID should be greater than zero");

            throw new NotImplementedException();
        }

        public SupplierViewModel GetById(int id)
        {
            Validation.Create()
                .IsGreaterThan(id, 0, "Supplier ID should be greater than zero");

            throw new NotImplementedException();
        }

        public void UpdateStock(int articleId, int supplierId, ArticleStockState state)
        {
            Validation.Create()
                .IsGreaterThan(articleId, 0, "Article ID should be greater than zero")
                .IsGreaterThan(supplierId, 0, "Supplier ID should be greater than zero");

            throw new NotImplementedException();
        }
    }
}
