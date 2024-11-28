using demo.back.Domain.Entities;

namespace demo.back.Domain.Interfaces
{
    public class FavoriteInterfaces
    {

        public interface IFavoriteRepository
        {
            Task<IEnumerable<Favorite>> GetFavoritesByUserId(int id);
            Task<Favorite> AddAsync(Favorite favorite);
        }
    }
}
