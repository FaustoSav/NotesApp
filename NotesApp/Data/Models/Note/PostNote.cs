using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Models.Note
{
    public class PostNote
    {
        [Required]
        [StringLength(70)]
        public string Title { get; set; } = string.Empty;
  

    }
}
