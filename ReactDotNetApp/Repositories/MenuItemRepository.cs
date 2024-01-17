using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories.Interfaces;

namespace ReactDotNetApp.Repositories
{
    public class MenuItemRepository: GenericRepository<MenuItem>, IMenuItemRepository
    {
        private readonly AppDbContext _context;

        public MenuItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
