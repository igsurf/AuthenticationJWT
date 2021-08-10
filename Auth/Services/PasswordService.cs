using Auth.Commons;
using Auth.Models;
using FluentValidation;

namespace Auth.Services
{
    public class ValidatePassword : AbstractValidator<User> 
    {
        public ValidatePassword()
        {
           RuleFor(user => user.Password)
           .NotNull()
           .WithMessage("Necessário indicar um valor");
           
           RuleFor(user => user.Password)
           .Must(d => d.IsValidSequence())
           .WithMessage("Sequencia inválida");

           RuleFor(user => user.Password)
           .Must(d => d.HasValidSpecialChar())
           .WithMessage("Sem o caracter especial válido");
         
        }


        public static bool CreatePassword(User user)
        {
            
            var validation = true;

            return validation;
        }


    }
}