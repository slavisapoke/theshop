using AutoMapper;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Helpers;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Interfaces.Repository;
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
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierArticleRepository _stockRepository;

        public SupplierService(IMapper mapper, 
            ISupplierRepository supplierRepository,
            ISupplierArticleRepository stockRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _stockRepository = stockRepository;
        }

        public int Add(SupplierViewModel supplier)
        {
            Validation.Create()
                   .NotNullOrEmpty(supplier, "Supplier should not be null")
                   .IsTrue(supplier.ID == 0, "Supplier ID should be zero")
                   .NotNullOrEmpty(supplier.Name, "Supplier name should not be null or empty")
                   .Execute();


            var supplierDb = _mapper.Map<Supplier>(supplier);
            supplierDb = _supplierRepository.Add(supplierDb);

            return supplierDb.ID;
        }

        public SupplierViewModel GetById(int id)
        {
            Validation.Create(false)
                .IsGreaterThan(id, 0, "Supplier ID should be greater than zero");

            var suppDb = _supplierRepository.GetById(id); 

            return _mapper.Map<SupplierViewModel>(suppDb);
        }
    }
}
