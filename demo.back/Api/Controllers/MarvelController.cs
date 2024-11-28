using demo.back.Api.DTOs;
using demo.back.API.DTOs;
using demo.back.Application.Services;
using demo.back.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace demo.back.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarvelController : ControllerBase
    {
        private readonly MarvelApiService _marvelService;

        public MarvelController(MarvelApiService marvelService)
        {
            _marvelService = marvelService;
        }


        [HttpPost("get-paginated-comics")]
        public async Task<IActionResult> GetComics([FromBody] ComicsFilterDTO request)
        {
            var res = await _marvelService.GetComicsAsync(
                request.Title,
                request.Page,
                request.PerPage
            );

            return Ok(res);
        }

    } 

}
