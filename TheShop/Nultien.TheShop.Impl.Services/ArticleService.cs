using AutoMapper;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Interfaces.Repository;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IMapper mapper, 
            IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public ArticleViewModel GetById(int id)
        {
            var article = _articleRepository.GetById(id);

            return _mapper.Map<ArticleViewModel>(article);
        }
    }
}
