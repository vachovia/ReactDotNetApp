using AutoMapper;
using ReactDotNetApp.DTO;
using ReactDotNetApp.Models;

namespace ReactDotNetApp.AutoMapperConfig
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<MenuItemDto, MenuItem>().ReverseMap();
            CreateMap<MenuItemCreateDto, MenuItem>().ReverseMap();
            CreateMap<MenuItemUpdateDto, MenuItem>().ReverseMap();
        }
    }
}
