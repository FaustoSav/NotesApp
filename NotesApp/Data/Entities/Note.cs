using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Entities
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        [Required]
        [StringLength(70)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public bool IsArchived { get; set; } = false;


        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
