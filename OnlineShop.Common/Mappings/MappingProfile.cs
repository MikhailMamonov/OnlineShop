using AutoMapper;

using OnlieShop.Domain.Models.DTO;

using OnlineShop.Models.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Common.Mappings
{
    public class MappingProfile: Profile
    {
        CreateMap<User, UserDTO>(); //Map from Developer Object to DeveloperDTO Object
    }
}
