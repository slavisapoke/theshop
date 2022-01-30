namespace Nultien.TheShop.Common.DTO
{
    public class ArticleSearchParams
    {
        public string Name { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
