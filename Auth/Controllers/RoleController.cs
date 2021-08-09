using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Auth.Services;
using Auth.Repositories;
using FluentValidation.Results;
using Auth.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers
{
    [Route("v1/account")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token.TokenNumber,
                expirationTime = token.ExpiratioNTime
            };
        }

        [HttpPost]
        [Route("validate")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ValidatePassword([FromBody]User model) 
        {

            var user = UserRepository.Get(model.Username, model.Password); 

            ValidatePassword validator = new ValidatePassword();
            ValidationResult results = validator.Validate(user);

            if (results.IsValid)
            {
                return "allowed";
            }
            
            return "not allowed";

        }

        [HttpPost]
        [Route("createkey")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> CreatePassword( [FromServices] DataContext context,
            [FromBody]User model)  
        {
           if (ModelState.IsValid)
           {

               context.Users.Add(model);
               await context.SaveChangesAsync();
               return model;

           }

           // var user = UserRepository.Get(model.Username, model.Password); 
           // ValidatePassword validator = new ValidatePassword();
            //ValidationResult results = validator.Validate(user);

            // if (results.IsValid)
            // {
            //     return "allowed";
            // }

            
            
            return "not allowed";

        }


        [HttpGet]
        [Route("listkey")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ListarUsuarios( [FromServices] DataContext context)  
        {
           var users = await context.Users.ToListAsync();

           return users;

           // var user = UserRepository.Get(model.Username, model.Password); 
           // ValidatePassword validator = new ValisdatePassword();
            //ValidationResult results = validator.Validate(user);

            // if (results.IsValid)
            // {
            //     return "allowed";
            // }

            
            
            // return "not allowed";

        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);



    }
}