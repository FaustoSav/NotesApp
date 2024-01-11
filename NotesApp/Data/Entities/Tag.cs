using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Entities
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [Required]
        [StringLength(30)] 
        public string Name { get; set; } = string.Empty;
        [StringLength(70)] 
        public string Description { get; set; } = string.Empty;

        public string Color { get; set; } = "#333";

        public bool State { get; set; } = true;
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
