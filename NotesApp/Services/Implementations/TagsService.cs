using Microsoft.EntityFrameworkCore;
using NotesApp.Data.DBContext;
using NotesApp.Data.Entities;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementations
{
    public class TagsService : ITagsService
    {
        private readonly NotesContext _notesContext;

        public TagsService(NotesContext notesContext)
        {
            _notesContext = notesContext;
        }

        public void CreateTag(string tagName, int userId)
        {
            // Verificar si el tag ya existe para el usuario
            if (!_notesContext.Tags.Any(t => t.Name == tagName && t.UserId == userId))
            {
                var newTag = new Tag
                {
                    Name = tagName,
                    UserId = userId
                    // Puedes agregar otras propiedades aquí si es necesario
                };

                _notesContext.Tags.Add(newTag);
                _notesContext.SaveChanges();
            }
        }

        public void DeleteTag(string tagName, int userId)
        {
            var tagToDelete = _notesContext.Tags.FirstOrDefault(t => t.Name == tagName && t.UserId == userId);

            if (tagToDelete != null)
            {
                _notesContext.Tags.Remove(tagToDelete);
                _notesContext.SaveChanges();
            }
        }

        public void RemoteTagFromNote(string tagName, int userId, int noteId)
        {
            var note = _notesContext.Notes
                .Include(n => n.Tags)
                .FirstOrDefault(n => n.NoteId == noteId && n.UserId == userId);

            if (note != null)
            {
                var tagToRemove = note.Tags.FirstOrDefault(t => t.Name == tagName);

                if (tagToRemove != null)
                {
                    note.Tags.Remove(tagToRemove);
                    _notesContext.SaveChanges();
                }
            }
        }

        public void AddTagToNote(string tagName, int userId, int noteId)
        {
            var note = _notesContext.Notes
                .Include(n => n.Tags)
                .FirstOrDefault(n => n.NoteId == noteId && n.UserId == userId);

            if (note != null && !note.Tags.Any(t => t.Name == tagName))
            {
                var tagToAdd = new Tag
                {
                    Name = tagName,
                    UserId = userId
                };

                note.Tags.Add(tagToAdd);
                _notesContext.SaveChanges();
            }
        }

 
    }
}
