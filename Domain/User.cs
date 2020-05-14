using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster
{
    public class User
    {
        public string Email { get; set; }

        public string  Nickname { get; set; }

        public string Password { get; set; }

        //public string Salt { get; set; }


        public User(string email, string nickname, string password)
        {
            Email = email;
            Nickname = nickname;
            Password = password;
        }

        public User()
        {
        }
    }
}
