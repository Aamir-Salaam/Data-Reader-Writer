using AutoMapper;
using Data_Reader_Writer.Models;

namespace Data_Reader_Writer.Logic.Mappers
{

    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
            : this("DemoAppProfile")
        {
        }
        protected AutoMapperProfileConfig(string profileName)
            : base(profileName)
        {
            CreateMap<YamlProduct, ProductInfo>()
                .ForMember(pi => pi.Name, dest => dest.MapFrom(src => src.name))
                .ForMember(pi => pi.Categories, dest => dest.MapFrom(src => src.tags))
                .ForMember(pi => pi.TwitterHandle, dest => dest.MapFrom(src => "@" + src.twitter));

            CreateMap<JsonProduct, ProductInfo>()
                .ForMember(pi => pi.Name, dest => dest.MapFrom(src => src.title))
                .ForMember(pi => pi.Categories, dest => dest.MapFrom(src => string.Join(",", src.categories)))
                .ForMember(pi => pi.TwitterHandle, dest => dest.MapFrom(src => src.twitter != null ? src.twitter : null));
        }
    }
}
