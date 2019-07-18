using System.ComponentModel.DataAnnotations;

namespace canadiansportsball.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}