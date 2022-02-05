using Nultien.TheShop.Common.DTO;
using System.Collections.Generic;

namespace Nultien.TheShop.Interfaces.Services
{
    public interface IShopService
    {
        /// <summary>
        /// Gets an article by the given ID  
        /// </summary>
        /// <param name="id">Article Id</param>
        /// <returns></returns>
        ArticleViewModel GetById(int id);

        /// <summary>
        /// Sells an article by the given id to a buyer with the given id. 
        /// This API is a part of larger enterprise system (by the assignment) so not gonna change API, 
        /// or not going to get deeper behind the idea of having maxExpectedPrice in this stage of shopping flow
        /// </summary>
        /// <param name="id">Article Id</param>
        /// <param name="maxExpectedPrice">max price for validation</param>
        /// <param name="buyerId">Id of a customer buying given article</param>
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
    }
}
