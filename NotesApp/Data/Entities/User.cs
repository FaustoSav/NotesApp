using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Entities
{
    public  class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? LastName { get; set; }
        public string? Password { get; set; } 
        public string? Email { get; set; } 
        [Required]
        public string? UserName { get; set; }

        public bool State { get; set; } = true;
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    }
}
