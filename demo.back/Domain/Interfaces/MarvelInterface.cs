using demo.back.Domain.Entities;

namespace demo.back.Domain.Interfaces
{
    public interface IMarvelApiService
    {
        Task<IEnumerable<Comic>> GetComicsAsync();
        Task<Comic> GetComicByIdAsync(int comicId);
    }
}
