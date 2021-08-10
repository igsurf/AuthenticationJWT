using System.Collections.Generic;
using System.Linq;
using Auth.Models;

namespace Auth.Repositories
{
    public static class UserRepository
    {
        
        public static User Get(string username, string password) 
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, Username = "joe", Password = "b1d3N", Role = "admin" });
            users.Add(new User { Id = 2, Username = "donald", Password = "tr#mP", Role = "guest" });


            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
            
        }
    }
}