using demo.back.Application.Utils;
using demo.back.Domain.Entities;
using static demo.back.Domain.Interfaces.FavoriteInterfaces;


namespace demo.back.Application.Services
{
    public class FavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<ApiResponse<IEnumerable<Favorite>>> GetFavoritesByUserIdAsync(int id)
        {
            var res = await _favoriteRepository.GetFavoritesByUserIdAsync(id);
            return new ApiResponse<IEnumerable<Favorite>>(res, EResponseCodes.Success);
        }

        public async Task<ApiResponse<Favorite>> AddFavoriteAsync(Favorite favorite)
        {
            var res = await _favoriteRepository.AddAsync(favorite);
            return new ApiResponse<Favorite>(res, EResponseCodes.Success);
        }

    }
}
