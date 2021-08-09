using Xunit;
using Auth.Models;
using Auth.Services;
using System;

namespace Auth.Tests

{
    public class GenerateTokenTest
    {
        [Fact]
        public void CreateToken()
        {
            var user = new User();
            user.Username = "robin";
            user.Role = "robin";

            var token = new Token();
            token.ExpiratioNTime = DateTime.UtcNow.AddMinutes(5).ToString();



            var result = TokenService.GenerateToken(user);

            //var result = "";
        
            Assert.Equal(token, result);
        
        //When
        
        //Then
        }
        
    }
}