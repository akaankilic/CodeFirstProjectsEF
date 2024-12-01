using AutoMapper;
using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;

namespace PeyverCom.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductCreateDto, Product>();
        }
    }
}
