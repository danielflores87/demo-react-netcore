using demo.back.Domain.Entities;

namespace demo.back.API.DTOs
{
    public class UserDto
    {
        public string NumberDocument { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthUserDTO
    {
        public User User { get; set; }
        public string Token { get; set; }

        public AuthUserDTO(User user, string token)
        {
            this.User = user;
            this.Token = token;

        }
    }

    public class UserPaginationRequestDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PerPage { get; set; }
        public int Page { get; set; }
    }
}
