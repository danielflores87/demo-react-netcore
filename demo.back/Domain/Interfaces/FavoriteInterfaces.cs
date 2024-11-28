using demo.back.Domain.Entities;

namespace demo.back.Domain.Interfaces
{
    public class FavoriteInterfaces
    {

        public interface IFavoriteRepository
        {
            Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int id);
            Task<Favorite> AddAsync(Favorite favorite);
        }
    }
}
