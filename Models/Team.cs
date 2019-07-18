using System.ComponentModel.DataAnnotations;

namespace canadiansportsball.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mascot { get; set; }
    }
}