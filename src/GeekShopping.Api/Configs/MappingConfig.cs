using AutoMapper;
using GeekShopping.Api.Data.ValueObjects;
using GeekShopping.Api.Models;

namespace GeekShopping.Api.Configs
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVo, Product>();
                config.CreateMap<Product, ProductVo>();
            });
            return mappingConfig;
        }
    }
}
