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

namespace Nultien.TheShop.Test.Services
{
    [TestFixture]
    public class ArticleServiceTest
    {
        private IFixture _fix;
        private Mock<IArticleRepository> _articleRepositoryMock;
        private IArticleService _articleService;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _fix = new Fixture().Customize(new AutoMoqCustomization());
            _articleRepositoryMock = new Mock<IArticleRepository>();

            _articleRepositoryMock.Setup(m => m.GetById(1)).Returns(
                CreateDefaultArticle());
            _articleRepositoryMock.Setup(m => m.Add(It.IsAny<Article>())).Returns(
                CreateDefaultArticle());
            _fix.Inject(_articleRepositoryMock);

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(x => x.Map<ArticleViewModel>(CreateDefaultArticle())).Returns(CreateDefaultArticleViewModel());

            _fix.Inject(_mapperMock);
            _articleService = _fix.Create<ArticleService>();
        }

        /// <summary>
        /// Tests if repository getById is invoked
        /// </summary>
        [Test]
        public void GetArticleTest()
        {
            _articleService.GetById(1);
            _articleRepositoryMock.Verify(a => a.GetById(1), "Repository method GetById should be invoked");
        }

        /// <summary>
        /// Tests if getting article by ID=0 throws validation exception
        /// </summary>
        [Test]
        public void GetArticleByZeroIdThrowsValidationException()
        {
            Assert.Throws(
                Is.AssignableTo<ValidationExceptionBase>()
                .And.
                Message.StartsWith("ArticleService.GetById"),
                () => _articleService.GetById(0), "Validation exception should be thrown when querying by Zero id");
        }

        [Test]
        public void AddArticleTest()
        {
            var article = CreateDefaultArticleViewModel();
            _articleService.Add(article);
            _articleRepositoryMock.Verify(x => x.Add(It.IsAny<Article>()), "Add Article must invoke Articlerepository.Add method");
        }


        private Article CreateDefaultArticle()
        {
            return new Article
            {
                Name = "Article",
                Price = 100
            };
        }

        private ArticleViewModel CreateDefaultArticleViewModel()
        {
            return new ArticleViewModel
            {
                Name_of_article = "Article",
                ArticlePrice = 100
            };
        }
    }
}
