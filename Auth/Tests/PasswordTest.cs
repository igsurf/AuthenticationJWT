using Xunit;
using Auth.Models;
using Auth.Services;
using FluentValidation.Results;

namespace Auth.Tests

{
    public class PasswordTest
    {
        [Fact]
        public void ValidatePassword()
        {
            var result = string.Empty;
            var user = new User();
            user.Username = "robin";
            user.Role = "robin";
            

            ValidatePassword validator = new ValidatePassword();
            ValidationResult results = validator.Validate(user);

            if(!results.IsValid)
            {
                foreach(var failure in results.Errors) 
                
                {
                  result =   failure.PropertyName + failure.ErrorMessage;
                }
            }

            //var result = "";
        
            Assert.Equal("", result);
        
        //When
        
        //Then
        }

        [Fact]
        public void CreatePassword()
        {
            var result = string.Empty;
            var user = new User();
            user.Username = "robin";
            user.Role = "robin";

            
            ValidatePassword validator = new ValidatePassword();
            ValidationResult results = validator.Validate(user);

             if(!results.IsValid)
            {
                foreach(var failure in results.Errors) 
                
                {
                  result =   failure.PropertyName + failure.ErrorMessage;
                }
            }

            //var result = "";
        
            Assert.Equal("", result);
        
        //When
        
        //Then
        }
        
    }
}