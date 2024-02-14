using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactDotNetApp.DTO.ShoppingCartDto;
using ReactDotNetApp.Repositories.Interfaces;
using ReactDotNetApp.Static;

namespace ReactDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public ActionResult<ShoppingCartDto> GetShoppingCart(string userId)
        {
            try
            {
                var shoppingCartDto = _shoppingCartRepository.GetShoppingCart(userId);

                return Ok(shoppingCartDto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"{Messages.Error500Message}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDto>> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQuantityBy)
        {
            try
            {
                var shoppingCartDto = await _shoppingCartRepository.AddOrUpdateItemInCart(userId, menuItemId, updateQuantityBy);

                if (shoppingCartDto == null)
                {
                    return BadRequest();
                }

                return Ok(shoppingCartDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{Messages.Error500Message}: {ex.Message}");
            }
        }
    }
}
