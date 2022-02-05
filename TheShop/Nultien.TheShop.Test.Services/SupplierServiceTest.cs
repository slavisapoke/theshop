using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Moq;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Exceptions.Validation;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Impl.Services;
using Nultien.TheShop.Interfaces.Repository;
using Nultien.TheShop.Interfaces.Services;
using NUnit.Framework;
using System;

namespace Nultien.TheShop.Test.Services
{
    [TestFixture]
    public class SupplierServiceTest
    {
        private IFixture _fix;
        private Mock<ISupplierRepository> _supplierRepositoryMock;
        private ISupplierService _supplierService;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
            _supplierRepositoryMock = new Mock<ISupplierRepository>();

            _supplierRepositoryMock.Setup(m => m.GetById(1)).Returns(
                CreateDefaultSupplier());
            _supplierRepositoryMock.Setup(m => m.Add(It.IsAny<Supplier>())).Returns(
                CreateDefaultSupplier());

            _fix.Inject(_supplierRepositoryMock);

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(x => x.Map<SupplierViewModel>(CreateDefaultSupplier())).Returns(CreateDefaultSupplierViewModel());

            _fix.Inject(_mapperMock);
            _supplierService = _fix.Create<SupplierService>();
        }

        /// <summary>
        /// Tests if repository getById is invoked
        /// </summary>
        [Test]
        public void GetSupplierTest()
        {
            _supplierService.GetById(1);
            _supplierRepositoryMock.Verify(a => a.GetById(1), "Repository method GetById should be invoked");
        }

        /// <summary>
        /// Tests getById with ID=0 throws validation exception
        /// </summary>
        [Test]
        public void GetArticleByZeroIdThrowsValidationException()
        {
            Assert.Throws(
                Is.AssignableTo<ValidationExceptionBase>()
                .And.
                Message.StartsWith("SupplierService.GetById"),
                () => _supplierService.GetById(0), "Validation exception should be thrown when querying by Zero id");
        }

        [Test]
        public void AddSupplierTest()
        {
            var supplier = CreateDefaultSupplierViewModel();
            _supplierService.Add(supplier);
            _supplierRepositoryMock.Verify(x => x.Add(It.IsAny<Supplier>()), "Add Supplier must invoke ISupplierRepository.Add method");
        }


        private SupplierViewModel CreateDefaultSupplierViewModel()
        {
            return new SupplierViewModel { Name = "Supplier 1" };
        }

        private Supplier CreateDefaultSupplier()
        {
            return new Supplier {  Name = "Supplier 1" };
        }
    }
}
