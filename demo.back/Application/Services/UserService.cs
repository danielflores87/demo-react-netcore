using demo.back.Application.Utils;
using demo.back.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using static demo.back.Domain.Interfaces.UserInterfaces;

namespace demo.back.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApiResponse<IEnumerable<User>>> GetUsersPaginatedAsync(string? name, string? email, int perPage, int page)
        {
            var (users, total) = await _userRepository.GetUsersPaginatedAsync(name, email, perPage, page);

            return new ApiResponse<IEnumerable<User>>(users, EResponseCodes.Success, null, total);
            
        }
        public async Task<ApiResponse<User>> CreateUserAsync(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            var res = await _userRepository.AddAsync(user);
           
            return new ApiResponse<User>(res, EResponseCodes.Success);
        }

        public async Task DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);
    }
}
