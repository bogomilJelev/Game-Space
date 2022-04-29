using System.ComponentModel.DataAnnotations;

namespace GameSpace.Models.Games
{
    public class AllGameQueryModel
    {
        public const int GamePerPage = 10;
        public IEnumerable<GameListVIewModel> Games { get; set; }
        [Display(Name = "Search")]
        public string SearchTerm { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalGames { get; set; }

    }
}
