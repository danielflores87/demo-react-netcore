
namespace demo.back.Domain.Entities
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Thumbnail Thumbnail { get; set; }

        public Characters Characters { get; set; }

        public List<PriceItems> Prices { get; set; }
    }


    public class PriceItems
    {
        public string Type { get; set; }
        public float Price { get; set; }

    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Characters
    {
        public List<CharacterItem> Items { get; set; }
    }

    public class CharacterItem
    {
        public string Name { get; set; }
    }

}


