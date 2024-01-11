using NotesApp.Data.Entities;
using NotesApp.Data.Models.User;

namespace NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        public BaseResponse ValidarUsuario(string username, string password);
      
        public User? GetUserByEmail(string email);

        public User? GetUserById(int id);
        public int? GetCurrentUser();
    }
}
