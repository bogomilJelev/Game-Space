namespace GameSpace.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; } = new List<Game>();

        public string Description { get; set; }
    }
}
