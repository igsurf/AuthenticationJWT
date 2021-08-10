using Xunit;
using Auth.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Auth.Commons;

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
            

           



            //var result = "";
        
            Assert.Equal("", result);
        

        }

        [Fact]
        public void CreatePassword()
        {

            string input = "wooooooowo happppppppyff@";
            var result = StringCommons.IsValidSequence(input);
            result = StringCommons.HasValidSpecialChar(input);

            Console.Read();

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            DbContext db = new DbContext(optionsBuilder.Options);

        
            Assert.True(result);

        }
        
    }
}