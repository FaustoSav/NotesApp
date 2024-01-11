using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Models.Note
{
    public class NoteUpdateDto
    {
     
        [StringLength(70)]
        public string? Title { get; set; }
        public bool? IsActive { get; set; } 
        public bool? IsArchived { get; set; }
        public int? Tag { get; set; }
    }
}
