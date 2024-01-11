using Microsoft.AspNetCore.Mvc;
using NotesApp.Data.Entities;
using NotesApp.Data.Models.Note;
using NotesApp.Services.Interfaces;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllNotes(int userId)
        {
            try
            {
                List<Note> notes = _notesService.GetNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener las notas: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult CreateNote(int userId, [FromBody] PostNote postNote)
        {
            try
            {
                _notesService.AddNote(userId, postNote);
                return Ok("Nota creada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la nota: {ex.Message}");
            }
        }

        [HttpPut("{noteId}")]
        public IActionResult EditNote(int userId, int noteId, [FromBody] NoteUpdateDto editNote)
        {
            try
            {
                _notesService.EditNote(noteId,userId, editNote);
                return Ok("Nota editada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al editar la nota: {ex.Message}");
            }
        }

        [HttpPatch("{noteId}/archive")]
        public IActionResult ArchiveNote(int userId, int noteId)
        {
            try
            {
                _notesService.ArchiveNote(noteId, userId );
                return Ok("Nota archivada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al archivar la nota: {ex.Message}");
            }
        }

        [HttpPatch("{noteId}/unarchive")]
        public IActionResult UnarchiveNote(int userId, int noteId)
        {
            try
            {
                _notesService.UnarchiveNote(noteId,userId);
                return Ok("Nota desarchivada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al desarchivar la nota: {ex.Message}");
            }
        }

        [HttpPatch("{noteId}/restore")]
        public IActionResult RestoreNote(int userId, int noteId)
        {
            try
            {
                _notesService.RestoreNote(userId, noteId);
                return Ok("Nota restaurada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al restaurar la nota: {ex.Message}");
            }
        }
        //public List<Note> GetNotes(int userId
  
        [HttpDelete("{noteId}")]
        public IActionResult RemoveNote(int userId, int noteId)
        {
            try
            {
                _notesService.RemoveNote(noteId,userId);
                return Ok("Nota eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la nota: {ex.Message}");
            }
        }
        [HttpDelete("DeletePermanently/{noteId}")]
        public IActionResult DeletePermanently(int userId, int noteId)
        {
            try
            {
                _notesService.DeletePermanently(noteId,userId);
                return Ok("Nota eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la nota: {ex.Message}");
            }
        }
    }
}
