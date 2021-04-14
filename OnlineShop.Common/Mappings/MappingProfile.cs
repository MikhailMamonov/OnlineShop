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
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}