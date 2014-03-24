

namespace UsersProj
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class User
    {
        private string password;
        private int id;
        public string Login { get; private set; }
        public string Role { get; private set; }

        public User()
        {
            this.password = "nopas";
            this.id = -1;
            this.Login = "nologin";
            this.Role = "norole";
        }
        public User(string password, int id, string login, string role)
        {
            this.password = password;
            this.id = id;
            this.Login = login;
            this.Role = role;
        }
    }
}
