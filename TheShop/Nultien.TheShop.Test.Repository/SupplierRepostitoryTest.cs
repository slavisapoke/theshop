using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Nultien.TheShop.Common.Exceptions.Entity;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Impl.Repository;
using Nultien.TheShop.Interfaces.Repository;
using NUnit.Framework;

namespace Nultien.TheShop.Test.Repository
{
    [TestFixture]
    public class SupplierRepostitoryTest
    {
        private IFixture _fix;
        private ISupplierRepository _supplierRepository;
        private Mock<ILogger<SupplierRepostitoryTest>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
            _loggerMock = new Mock<ILogger<SupplierRepostitoryTest>>();

            var dbContext = new ShopDbContext(
                 new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDatabaseTest")
                    .Options);
            
            _fix.Inject(dbContext);
            _fix.Inject(_loggerMock); 

            _supplierRepository = _fix.Create<SupplierRepository>();
        }

        /// <summary>
        /// Tests if suppliers are added
        /// </summary>
        /// <param name="name"></param>
        [Test]
        [Order(1)]
        [TestCase( "Supplier1")]
        [TestCase( "Supplier2")] 
        public void AddSuppliers_Test(string name)
        {
            var supplier = new Supplier { Name = name };

            var responseInstance = _supplierRepository.Add(supplier);

            Assert.IsTrue(responseInstance.ID > 0, "Persisted supplier must be given new ID");
        }

        /// <summary>
        /// Tests if supplier is added and returned by GetById method
        /// </summary>
        /// <param name="name"></param>
        [Test]
        [Order(2)]
        [TestCase("Supplier3")]
        public void AddSupplier_GetById(string name)
        {
            var supplier = new Supplier { Name = name };

            var res = _supplierRepository.Add(supplier);

            Assert.IsTrue(res.ID > 0, "Persisted supplier must be given new ID");

            var responseInstance = _supplierRepository.GetById(res.ID);

            Assert.AreEqual(res.ID, responseInstance.ID, "Returned supplier must have the same ID as persisted");
        }


        /// <summary>
        /// Tests if adding supplier with existing name throws EntityAddException
        /// </summary>
        /// <param name="name"></param>
        [Test]
        [Order(3)] 
        public void AddExistingSupplierThrowsException()
        {
            const string name = "SupplierDuplicate";
            var supplier = new Supplier { Name = name };

            var responseInstance = _supplierRepository.Add(supplier);

            Assert.IsTrue(responseInstance.ID > 0, "Persisted supplier must be given new ID");

            var exception = Assert.Throws<EntityAddException>(() =>
                _supplierRepository.Add(new Supplier
                {
                    Name = name
                }),
                "Adding existing supplier must throw EntityAddException"
             );

            Assert.AreEqual(exception.EntityType, typeof(Supplier).FullName,
                "EntityAddException must contain fully qualified name of class Supplier");
        }
    }
}
