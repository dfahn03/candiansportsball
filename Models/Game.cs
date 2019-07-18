using System.ComponentModel.DataAnnotations;

namespace canadiansportsball.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        public int WinningTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}