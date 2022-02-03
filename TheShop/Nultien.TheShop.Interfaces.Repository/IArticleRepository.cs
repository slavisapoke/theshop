using Nultien.TheShop.DataDomain;

namespace Nultien.TheShop.Interfaces.Repository
{
    public interface IArticleRepository
    {
        Article GetById(int id);
        Article Add(Article article); 
    }
}
