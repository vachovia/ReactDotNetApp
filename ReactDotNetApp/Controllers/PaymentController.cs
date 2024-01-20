using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;
using Stripe;
using System.Net;

namespace ReactDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IConfiguration _congifuration;
        private readonly AppDbContext _db;

        public PaymentController(IConfiguration configuration, AppDbContext db)
        {
            _db = db;
            _response = new();
            _congifuration = configuration;
        }

        [HttpPost]
        public ActionResult<ApiResponse> MakePayment(string userId)
        {
            ShoppingCart shoppingCart = _db.ShoppingCarts
                .Include(u => u.CartItems)
                .ThenInclude(u => u.MenuItem).FirstOrDefault(u => u.UserId == userId);

            if (shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            #region Create Payment Intent

            StripeConfiguration.ApiKey = _congifuration["Stripe:ApiKey"];

            shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.MenuItem.Price);

            PaymentIntentCreateOptions options = new()
            {
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string>{ "card" }
            };

            PaymentIntentService service = new();

            PaymentIntent response = service.Create(options);

            shoppingCart.StripePaymentIntentId = response.Id;
            shoppingCart.ClientSecret = response.ClientSecret;

            #endregion

            _response.Result = shoppingCart;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

    }
}

// ApiKey = configuration.GetValue<string>("Stripe:ApiKey")
// apiKey='pk_test_51Kb5VDIbFLvvlEjSZaexkN8qyebzWWe8dZyn0OFf819fR6Cntd9Ja4rWd4ASdjvr6jM0yuX0BgWW1ToSgtvuczR400uBgROxku'