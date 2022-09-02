using System;
using AutoMapper;
using ZeroToHero.CodeFirst.DAL;
using ZeroToHero.CodeFirst.DTOs;

namespace ZeroToHero.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDTOs, Product>().ReverseMap();
        }
    }
}

