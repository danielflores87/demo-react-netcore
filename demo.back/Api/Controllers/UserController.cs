using demo.back.API.DTOs;
using demo.back.Application.Services;
using demo.back.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace demo.back.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var user = new User
            {
                NumberDocument = userDto.NumberDocument,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };

            var res = await _userService.CreateUserAsync(user);
            return Ok(res);
        }

        [HttpPost("get-users-paginated")]
        public async Task<IActionResult> GetUsersPaginated([FromBody] UserPaginationRequestDTO request)
        {
            var result = await _userService.GetUsersPaginatedAsync(request.Name, request.Email, request.PerPage, request.Page);
            return Ok(result);
        }


        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            throw new NotImplementedException("Api: Metodo no Implementado...");
        }
    }
}
