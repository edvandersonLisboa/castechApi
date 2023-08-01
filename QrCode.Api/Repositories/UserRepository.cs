using QrCode.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace QrCode.Api.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var Users = new List<User>();
            Users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role ="manager" });
            Users.Add(new User { Id = 1, Username = "robin", Password = "robin", Role = "employee" });
            return Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).ToList().FirstOrDefault();
        }
    }
}
