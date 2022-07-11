using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.AutoMapper.DTO;
using UdemyEFCore.AutoMapper.Entity;

namespace UdemyEFCore.AutoMapper.Mappers
{
    public class ObjectMapper
    {
        private static Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper mapper=> lazy.Value;
    }

    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
