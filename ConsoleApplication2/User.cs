using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
      public abstract class User
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gamertag { get; set; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public abstract void Post(string content);
        internal abstract void Comment(IPost post, string content);
    }
}
