using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Common.Mappings;
using OnlineShop.Services;
using OnlineShop.Services.Implementations;
using OnlineShop.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services) 
        {
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IUsersService, UsersService>();
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

    }
}
