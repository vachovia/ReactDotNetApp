using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories.Interfaces;

namespace ReactDotNetApp.Repositories
{
    public class CartItemRepository: GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
