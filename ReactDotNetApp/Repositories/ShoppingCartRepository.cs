using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.DataAccess;
using ReactDotNetApp.DTO.ShoppingCartDto;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories.Interfaces;
using System.Net;

namespace ReactDotNetApp.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ICartItemRepository _cartItemRepository;

        public ShoppingCartRepository(AppDbContext context, ICartItemRepository cartItemRepository, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _cartItemRepository = cartItemRepository;
        }

        public ShoppingCartDto GetShoppingCart(string userId)
        {
            ShoppingCartDto shoppingCartDto = new();

            if (!string.IsNullOrEmpty(userId))
            {
                shoppingCartDto = _context.ShoppingCarts
                    .Include(u => u.CartItems).ThenInclude(u => u.MenuItem)
                    .ProjectTo<ShoppingCartDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(u => u.UserId == userId) ?? new();
            }

            if (shoppingCartDto.CartItems != null && shoppingCartDto.CartItems.Count > 0)
            {
                shoppingCartDto.CartTotal = shoppingCartDto.CartItems.Sum(u => u.Quantity * u.MenuItem.Price);
            }
            
            return shoppingCartDto;
        }

        public async Task<ShoppingCartDto> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQuantityBy)
        {
            ShoppingCart shoppingCart = _context.ShoppingCarts
                .Include(u => u.CartItems)
                .FirstOrDefault(u => u.UserId == userId);

            MenuItem menuItem = _context.MenuItems.FirstOrDefault(u => u.Id == menuItemId);

            if (menuItem == null) { return null; }

            if (shoppingCart == null && updateQuantityBy > 0)
            {
                ShoppingCart newCart = new()
                {
                    UserId = userId
                };
                await AddAsync(newCart);

                CartItem newCartItem = new()
                {
                    MenuItemId = menuItemId,
                    Quantity = updateQuantityBy,
                    ShoppingCartId = newCart.Id,
                    MenuItem = null // to avoid creating MenuItem
                };
                await _cartItemRepository.AddAsync(newCartItem);
            }
            else
            {
                CartItem cartItemInCart = shoppingCart.CartItems.FirstOrDefault(u => u.MenuItemId == menuItemId);

                if (cartItemInCart == null)
                {
                    CartItem newCartItem = new()
                    {
                        MenuItemId = menuItemId,
                        Quantity = updateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        MenuItem = null
                    };
                    await _cartItemRepository.AddAsync(newCartItem);
                }
                else
                {
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;

                    if (updateQuantityBy == 0 || newQuantity <= 0)
                    {
                        //remove cart item from cart and if it is the only item then remove cart
                        await _cartItemRepository.DeleteAsync(cartItemInCart.Id);

                        if (shoppingCart.CartItems.Count() == 1)
                        {
                            await DeleteAsync(shoppingCart.Id);
                        }
                    }
                    else
                    {
                        cartItemInCart.Quantity = newQuantity;

                        await _cartItemRepository.UpdateAsync(cartItemInCart);
                    }
                }
            }

            var shoppingCartDto = new ShoppingCartDto();

            _mapper.Map(shoppingCart, shoppingCartDto);

            return shoppingCartDto;
        }
    }
}
