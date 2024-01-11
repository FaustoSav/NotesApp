using Microsoft.AspNetCore.Components.Forms;
using NotesApp.Data.DBContext;
using NotesApp.Data.Entities;
using NotesApp.Data.Models.User;
using NotesApp.Services.Interfaces;
using System.Security.Claims;

namespace NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly NotesContext _notesContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(NotesContext notesContext, IHttpContextAccessor httpContextAccessor)
        {
            _notesContext = notesContext;
            _httpContextAccessor = httpContextAccessor;
        }


        public BaseResponse ValidarUsuario(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _notesContext.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

        public User? GetUserByEmail(string email)
        {
            return _notesContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserById(int userId)
        {
            return _notesContext.Users.SingleOrDefault(u => u.Id == userId && u.State);

        }
        public int? GetCurrentUser()
        {

            var userIdString = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userIdString != null ? int.Parse(userIdString) : (int?)null;

        }
    }
}
