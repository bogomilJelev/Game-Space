namespace GameSpace.Models.Games
{
    public class AddGameFormModel
    {
        public string Name { get; set; }    
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
    }
}
