using demo.back.Domain.Entities;

namespace demo.back.Api.DTOs
{
    public class ComicsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
        public string? Title { get; set; } = null;
    }


    public class ComicsResponseDTO
    {
        public ComicsDataDTO Data { get; set; }
    }

    public class ComicsDataDTO
    {
        public IEnumerable<Comic> Results { get; set; }
        public int Total { get; set; }
    }

}
