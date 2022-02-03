namespace Nultien.TheShop.Common.DTO
{
    public class ArticleSearchParams
    {
        public string Name { get; init; }
        public int MaxPrice { get; init; }
        public int MinPrice { get; init; }
        public int PageIndex { get; init; }
        public int PageSize { get; init; }
    }
}
