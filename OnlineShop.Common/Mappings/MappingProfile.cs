using AutoMapper;

using OnlieShop.Domain.Models.DTO;
using OnlieShop.Domain.Models.Entities;
using OnlineShop.Models.Entities;

namespace OnlineShop.Common.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryId, act=> act.MapFrom(src => src.CategoryId)).ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}