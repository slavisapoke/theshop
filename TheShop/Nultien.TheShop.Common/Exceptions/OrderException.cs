using Nultien.TheShop.Common.Enums;
using System;

namespace Nultien.TheShop.Common.Exceptions
{
    public class OrderException : Exception
    {
        public int ArticleId { get; private set; }
        public OrderStateEnum OrderState { get; private set; }

        public OrderException(int articleId, OrderStateEnum state)
            : base($"Failed with state {state} for article {articleId}")
        {
            OrderState = state;
            ArticleId = articleId;
        }
    }
}
