using System.ComponentModel.DataAnnotations;

namespace GameSpace.Models.Games
{
    public class AddGameFormModel
    {
        [Required]
        public string Name { get; set; }
        [MinLength(10)]
        public string Description { get; set; }

        [Display(Name="Image URL")]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<GameCategoryViewModel> Categories { get; set; }
    }

   
}
