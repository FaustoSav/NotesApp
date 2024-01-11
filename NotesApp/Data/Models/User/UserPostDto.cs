using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.Models.User
{
    public class UserPostDto
    {
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Name { get; set; }
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "La direccion de correo electronico es invalida.")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
