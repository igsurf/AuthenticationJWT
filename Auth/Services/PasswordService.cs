using Auth.Models;
using System;
using FluentValidation;

namespace Auth.Services
{
    public class ValidatePassword : AbstractValidator<User> 
    {
        public ValidatePassword()
        {
           RuleFor(user => user.Password).NotNull().WithMessage("ERRO LEGAL");
         
        }


        public static bool CreatePassword(User user)
        {

            

            var validation = true;

            return validation;
        }
    }
}