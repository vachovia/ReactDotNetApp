using AutoMapper;
using ReactDotNetApp.DTO.AuthDto;
using ReactDotNetApp.DTO.MenuDto;
using ReactDotNetApp.DTO.ShoppingCartDto;
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
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();

            CreateMap<AppUser, RegistrationDto>().ReverseMap();
        }
    }
}
