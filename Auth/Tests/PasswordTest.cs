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
        
            Assert.Equal("", result);
        

        }

        [Fact]
        public void CreatePassword()
        {

            //string input = "wooooooowo happppppppyff";
            string input = "e#";
            

            var resultValidaSequence = StringCommons.IsValidSequence(input);
            Console.WriteLine("IsvalidSequence {0}", resultValidaSequence);
            var resultHasSpecialChar = StringCommons.HasValidSpecialChar(input);
            Console.WriteLine("HasSpecialChar {0}", resultHasSpecialChar);


            Console.Read();

            Assert.True(resultHasSpecialChar);

        }
        
    }
}