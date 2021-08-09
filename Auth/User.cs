using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(15, ErrorMessage = "Digite 15 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(15, ErrorMessage = "Digite 15 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmation {get; set;}

        public string Role { get; set; }
    }
}