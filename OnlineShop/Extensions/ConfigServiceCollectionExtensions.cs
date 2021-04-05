using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OnlineShop.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddTransient<IProductsService, ProductsService>();
            return services;
        }
    }
}
