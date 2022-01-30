using AutoMapper;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.DataDomain;

namespace Nultien.TheShop.Impl.Services.Mapper
{
    /// <summary>
    /// Creates mapping between DataDomain and ViewModel classes
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(dest => dest.Name_of_article, 
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArticlePrice,
                    opt => opt.MapFrom(src => src.Price))
                .ReverseMap();

            CreateMap<Supplier, SupplierViewModel>()
                .ReverseMap();

            CreateMap<Common.DTO.Buyer, DataDomain.Buyer>().ReverseMap();
        }
    }
}
