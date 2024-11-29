using demo.back.Api.DTOs;
using demo.back.Application.Services;
using demo.back.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace demo.back.Api.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;

        public FavoriteController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost("add-favorite")]
        public async Task<ActionResult> AddFavorite(FavoriteDTO dto)
        {
            var favorite = new Favorite
            {
                UserId = dto.UserId,
                Titule = dto.Titule,
                CodeComic = dto.CodeComic,
                Date = DateTime.UtcNow
            };

            var res = await _favoriteService.AddFavoriteAsync(favorite);
            return Ok(res);
        }


        [HttpGet("get-by-user-id/{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var res = await _favoriteService.GetFavoritesByUserIdAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

    }
}
