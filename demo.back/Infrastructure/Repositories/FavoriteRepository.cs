using demo.back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static demo.back.Domain.Interfaces.FavoriteInterfaces;

namespace demo.back.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int id)
        {
            return await _context.Favorites.Where(u => u.UserId == id).ToListAsync();
        }

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }


    }
}
