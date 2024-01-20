using Microsoft.AspNetCore.Mvc;
using ReactDotNetApp.DTO.ShoppingCartDto;
using ReactDotNetApp.Models;
using System.Threading.Tasks;

namespace ReactDotNetApp.Repositories.Interfaces
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        ShoppingCartDto GetShoppingCart(string userId);
        Task<ShoppingCartDto> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQuantityBy);
    }
}
