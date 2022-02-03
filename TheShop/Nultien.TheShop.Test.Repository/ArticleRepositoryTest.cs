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
    public class ArticleRepositoryTest
    {
        private IFixture _fix;
        private IArticleRepository _articleRepository;
        private Mock<ILogger<ArticleRepositoryTest>> _loggerMock;
        
        public ArticleRepositoryTest()
        {
        }

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
            _loggerMock = new Mock<ILogger<ArticleRepositoryTest>>();

            var dbContext = new ShopDbContext(
                 new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDatabaseTest")
                    .Options);
            
            _fix.Inject(dbContext);
            _fix.Inject(_loggerMock); 

            _articleRepository = _fix.Create<ArticleRepository>();
        }

        /// <summary>
        /// Tests if articles are added
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        [Test]
        [Order(1)]
        [TestCase( "Article1", 100)]
        [TestCase( "Article2", 200)]
        [TestCase( "Article3", 300)]
        public void AddArticles_Test(string name, int price)
        {
            var article = CreateArticleInstance(name, price);

            var responseInstance = _articleRepository.Add(article);

            Assert.IsTrue(responseInstance.ID > 0, "Persisted article must be given new ID");
        }

        /// <summary>
        /// Tests if article is added and returned by GetById method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        [Test]
        [Order(2)]
        [TestCase( "Article1", 100)]
        public void AddArticle_GetById( string name, int price)
        {
            var article = CreateArticleInstance(name, price);
            var res = _articleRepository.Add(article);

            Assert.IsTrue(res.ID > 0, "Persisted article must be given new ID");

            var responseInstance = _articleRepository.GetById(res.ID);

            Assert.AreEqual(res.ID, responseInstance.ID, "Returned article must have the same ID as persisted");
        }

        /// <summary>
        /// Tests if GetById with none existing article throws EntityReadException
        /// </summary>
        [Test]
        [Order(3)]
        public void ArticleNotFoundThrowsException()
        {
            var exception = Assert.Throws<EntityReadException>(() => _articleRepository.GetById(0),
                "GetById must throw EntityReadException");

            Assert.AreEqual(exception.EntityType, typeof(Article).FullName, "EntityReadException must contain fullname of Article type");
            Assert.AreEqual(exception.EntityID, 0, "EntityReadException must contain searched ID");
        }

        #region Private methods

        /// <summary>
        /// Creates item by the given params
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private Article CreateArticleInstance(string name, int price)
        {
            return new Article { Name = name, Price = price };
        } 

        #endregion
    }
}
