using ReactDotNetApp.Models;

namespace ReactDotNetApp.DTO.ShoppingCartDto
{
    public class ShoppingCartDto
    {
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }       
        public double CartTotal { get; set; }        
        public string StripePaymentIntentId { get; set; }        
        public string ClientSecret { get; set; }
    }
}
