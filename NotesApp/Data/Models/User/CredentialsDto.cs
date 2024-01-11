using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Models.User
{
    public class CredentialsDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
