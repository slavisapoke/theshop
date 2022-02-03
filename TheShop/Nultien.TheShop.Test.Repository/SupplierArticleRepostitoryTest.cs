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
    public class SupplierArticleRepostitoryTest
    {
        private IFixture _fix;
        private ISupplierArticleRepository _stockRepository;
        private Mock<ILogger<SupplierArticleRepostitoryTest>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
            _loggerMock = new Mock<ILogger<SupplierArticleRepostitoryTest>>();

            var dbContext = new ShopDbContext(
                 new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDatabaseTest")
                    .Options);
            
            _fix.Inject(dbContext);
            _fix.Inject(_loggerMock); 

            _stockRepository = _fix.Create<SupplierArticleRepository>();
        }

        /// <summary>
        /// Tests if repository returns null if does not exist
        /// </summary>
        /// <param name="name"></param>
        [Test]
        [Order(1)]
        public void GetStocks_NotExistsTest()
        {
            var responseInstance = _stockRepository.Get(0, 0);

            Assert.IsNull(responseInstance, "Get should return null if no results by the given parameters");
        }

        /// <summary>
        /// Tests if supplier is added and returned by GetById method
        /// </summary>
        /// <param name="name"></param>
        [Test]
        [Order(2)]
        public void DeleteStockById()
        {
            var stock = CreateDefaultStock();

            var id = _stockRepository.Upsert(stock).ID;

            _stockRepository.Delete(id);

            var result = _stockRepository.Get(stock.ArticleID, stock.SupplierID);

            Assert.IsNull(result, "Deleted stock should return null");
        }

        [Test]
        [Order(3)]
        public void DeleteNoneExistingThrowsException()
        {
            const int id = 0;
            var exception = Assert.Throws<EntityDeleteException>(() =>
            {
                _stockRepository.Delete(id);
            });

            Assert.IsTrue(exception.EntityID == id, 
                "EntityDeletedException.EntityID should be equal given id");
            Assert.AreEqual(exception.EntityType, typeof(SupplierStock).FullName,
                "EntityDeletedException.EntityType should be equal to fully qualified name of class SupplierStock");
        }


        [Test]
        [Order(4)]
        public void UpsertStockTest()
        {
            var stock = CreateDefaultStock();

            var res = _stockRepository.Upsert(stock);

            Assert.NotNull(res, "Inserting new stock should return new instance");

            res.Price = 1000;

            _stockRepository.Upsert(res);

            res = _stockRepository.Get(res.ArticleID, res.SupplierID);

            Assert.AreEqual(res.Price, 1000, "Updating price should be persisted.");
        }

        private SupplierStock CreateDefaultStock()
        {
            return new SupplierStock
            {
                ArticleID = 1,
                SupplierID = 1,
                Price = 1,
                Quantity = 1
            };
        }
    }
}
