using NotesApp.Data.Entities;

namespace NotesApp.Services.Interfaces
{
    public interface ITagsService
    {
  

        void CreateTag(string tag, int userId);//Este metodo crea un tag en la base de datos
        void DeleteTag(string tag, int userId); //Este metodo elimina definitivament un tag
        void RemoteTagFromNote(string tag, int userId, int noteId); //Este metodo elimina un tag de una nota
        void AddTagToNote(string tag, int userId, int noteId);//Este metodo agrega un tag a una nota
    }
}
