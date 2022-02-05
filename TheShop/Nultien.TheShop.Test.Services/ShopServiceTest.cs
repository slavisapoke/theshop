using NUnit.Framework;
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
using System;
using System.Collections.Generic;
using Nultien.TheShop.Common.Exceptions;

namespace Nultien.TheShop.Test.Services
{
    [TestFixture]
    public class ShopServiceTest
    {
        private IFixture _fix;
        private Mock<ISupplierService> _supplierServiceMock;
        private Mock<ISupplierArticleRepository> _suplierArticleRepoMock;
        private IShopService _shopService;

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
      
            _suplierArticleRepoMock = new Mock<ISupplierArticleRepository>();

            
            _suplierArticleRepoMock.Setup(m => m.Get(1,1)).Returns(
                CreateStockInstance());

            _fix.Inject(_suplierArticleRepoMock);

            _shopService = _fix.Create<ShopService>();
        }

        [Test]
        public void OrderAndSellArticleTest()
        {
            _suplierArticleRepoMock.Setup(m => m.Search(1, null, 0, 0, true, 0, 1)).Returns(
                CreateArticleInStockSearchList());

            _shopService.OrderAndSellArticle(1, 0, 1);
            _suplierArticleRepoMock.Verify(m => m.Upsert(It.IsAny<SupplierStock>()), "OrderAndSell must invoke SupplierArticleRepository.Upsert"); 
        }

        [Test]
        public void OrderAndSellThrowsOrderException_WhenItemIsNoMoreInStock()
        {
            _suplierArticleRepoMock.Setup(m => m.Search(2, null, 0, 0, true, 0, 1)).Returns(new List<ArticleSearchViewModel>());
            Assert.Throws<OrderException>(() => _shopService.OrderAndSellArticle(2, 0, 1), "OrderAndSellArticle must throw exception if selling item is not in stock");
        }

        private SupplierStock CreateStockInstance()
        {
            return new SupplierStock
            {
                ArticleID = 1,
                ID = 1,
                Price = 100,
                SupplierID = 1,
                Quantity = 1
            };
        }

        private List<ArticleSearchViewModel> CreateArticleInStockSearchList()
        {
            return new List<ArticleSearchViewModel>
            {
                new ArticleSearchViewModel
                {
                    ArticleID = 1,
                    SupplierID = 1,
                    StockId = 1
                }
            };
        }
    }
}
