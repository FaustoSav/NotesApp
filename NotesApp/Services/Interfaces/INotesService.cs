using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NotesApp.Data.Entities;
using NotesApp.Data.Models.Note;
using System;

namespace NotesApp.Services.Interfaces
{
    public interface INotesService
    {
        //As a user, I want to be able to create, edit, and delete notes.
        //As a user, I want to archive/unarchive notes.
        //As a user, I want to list both my active notes.
        //As a user, I want to list both my archived notes.
        public List<Note> GetNotes(int userId);
        public void AddNote(int userId, PostNote note);
        public void RemoveNote(int noteId, int userId);
        public void RestoreNote(int userId, int noteId);
        public void ArchiveNote(int noteId, int userId);
        public void UnarchiveNote(int noteId, int userId);
        public void EditNote(int noteId, int userId, NoteUpdateDto editNote);
        public void DeletePermanently(int noteId, int userId);


    }
}
