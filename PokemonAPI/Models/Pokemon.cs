using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }
        
        public int Level { get; set; }
        public int? TrainerId { get; set; } // Foreign key
        public Trainer Trainer { get; set; }
        public int? TeamId { get; set; } // Foreign key
        public Team Team { get; set; }
    }
}
