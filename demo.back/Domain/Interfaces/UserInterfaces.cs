using demo.back.Domain.Entities;

namespace demo.back.Domain.Interfaces
{
    public class UserInterfaces
    {
        public interface IUserRepository
        {
            Task<(IEnumerable<User> Users, int Total)> GetUsersPaginatedAsync(string? name, string? email, int perPage, int page);
            Task<User> AddAsync(User user);
            Task DeleteAsync(int id);
            Task<User?> GetUserByEmailAsync(string email);
        }
    }
}
