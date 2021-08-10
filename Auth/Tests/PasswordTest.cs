using Xunit;
using Auth.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Auth.Commons;
using System.Collections.Generic;

namespace Auth.Tests

{
    public class PasswordTest
    {
        [Fact(Skip = "FECHANDO IMPLEMENTAÇÃO")]
        public void CreatePassword()
        {
            var result = string.Empty;
        
            Assert.Equal("", result);
        

        }

        [Theory(DisplayName = "VALIDANDO SENHAS")]
        [MemberData(nameof(PasswordList))]

        public void ValidatePassword(User user)
        {              

            var resultValidaSequence = StringCommons.IsValidSequence(user.Password);
            var resultHasSpecialChar = StringCommons.HasValidSpecialChar(user.Password);

            Console.Read();

            Assert.True(resultHasSpecialChar && resultValidaSequence);
        }


        public static IEnumerable<object[]> PasswordList => new []
        {
            //new [] {new User {Password = "wooooooowo happppppppyff" }},
            new [] {new User {Password = "ee%" }}
            //new [] {new User {Password = "2" }}
        };
        
    }
}