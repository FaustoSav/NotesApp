using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data.DBContext;
using NotesApp.Data.Entities;
using NotesApp.Data.Models.Note;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementations
{
    public class NotesServices : INotesService
    {

        private readonly NotesContext _notesContext;

        public NotesServices(NotesContext notesContext)
        {

            _notesContext = notesContext;


        }
        public List<Note> GetNotes(int userId)
        {
            return _notesContext.Notes.Where(n => n.UserId == userId).ToList();
        }
        public void AddNote(int userId, PostNote note)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                Note nuevaNota = new Note
                {
                    Title = note.Title,
                    UserId = userId,

                };
                _notesContext.Notes.Add(nuevaNota);
                _notesContext.SaveChanges();
            }
            else
            {
                throw new Exception("El usuario no existe.");
            }


        }

        public void ArchiveNote(int noteId, int userId)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                var nota = _notesContext.Notes.FirstOrDefault(n => n.NoteId == noteId);

                if (nota != null)
                {

                    nota.IsArchived = true;
                    _notesContext.SaveChanges();
                }
                else
                {

                    throw new Exception("No existe ninguna nota con ese ID.");
                }
            }
            else
            {

                throw new Exception("No existe un usuario con ese ID.");
            }
        }

        public void DeletePermanently(int noteId, int userId)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                var nota = _notesContext.Notes.FirstOrDefault(n => n.NoteId == noteId);

                if (nota != null)
                {

                    _notesContext.Notes.Remove(nota);
                    _notesContext.SaveChanges();
                }
                else
                {

                    throw new Exception("La nota no existe para el usuario especificado.");
                }
            }
            else
            {

                throw new Exception("No existe un usuario con ese ID.");
            }
        }

        public void EditNote(int noteId, int userId, NoteUpdateDto editNote)
        {
            var usuario = _notesContext.Users.Find(userId);
            var nota = _notesContext.Notes.FirstOrDefault(n => n.NoteId == noteId);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe.");
            }

            if (nota == null)
            {
                throw new Exception("La nota no existe para el usuario especificado.");
            }

            if (editNote == null)
            {
                throw new Exception("Mal formato o directamente nulo.");

            }

            nota.Title = editNote.Title ?? nota.Title;
            nota.IsActive = editNote.IsActive ?? false;
            nota.IsArchived = editNote.IsArchived ?? false;

            if (editNote.Tag != null)
            {
                var tag = nota.Tags.FirstOrDefault(t => t.TagId == editNote.Tag);

                if (tag == null)
                {
                    throw new Exception($"La etiqueta con ID {editNote.Tag} no está asociada a la nota.");
                }
                nota.Tags.Remove(tag);
            }

            _notesContext.SaveChanges();
        }





        public void RemoveNote(int noteId, int userId)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                var nota = usuario.Notes.FirstOrDefault(n => n.NoteId == noteId);

                if (nota != null)
                {

                    nota.IsActive = false;


                    _notesContext.SaveChanges();
                }
                else
                {

                    throw new Exception("La nota no existe para el usuario especificado.");
                }
            }
            else
            {

                throw new Exception("El usuario no existe.");
            }
        }

        public void UnarchiveNote(int noteId, int userId)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                var nota = usuario.Notes.FirstOrDefault(n => n.NoteId == noteId);

                if (nota != null)
                {

                    nota.IsArchived = false;

                    _notesContext.SaveChanges();
                }
                else
                {

                    throw new Exception("La nota no existe para el usuario especificado.");
                }
            }
            else
            {

                throw new Exception("El usuario no existe.");
            }
        }

        public void RestoreNote(int userId, int noteId)
        {

            var usuario = _notesContext.Users.Find(userId);

            if (usuario != null)
            {

                var nota = usuario.Notes.FirstOrDefault(n => n.NoteId == noteId);

                if (nota != null)
                {

                    nota.IsActive = true;


                    _notesContext.SaveChanges();
                }
                else
                {

                    throw new Exception("La nota no existe para el usuario especificado.");
                }
            }
            else
            {

                throw new Exception("El usuario no existe.");
            }



        }
    }
}
