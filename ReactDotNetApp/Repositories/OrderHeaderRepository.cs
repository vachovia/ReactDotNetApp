using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories.Interfaces;

namespace ReactDotNetApp.Repositories
{
    public class OrderHeaderRepository: GenericRepository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly AppDbContext _context;

        public OrderHeaderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
