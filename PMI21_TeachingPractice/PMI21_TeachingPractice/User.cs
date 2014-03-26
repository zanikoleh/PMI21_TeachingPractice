namespace UsersProj
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class User represents a user =)
    /// </summary>
    class User
    {
        private string password;
        public string Login { get; private set; }
        public Role Role { get; private set; }

        public User()
        {
            this.password = "nopas";
            this.Login = "nologin";
            this.Role = null;
        }
        public User(string password, string login, Role role)
        {
            this.password = password;
            this.Login = login;
            this.Role = new Role(role.Id,role.Duty);
        }
    }
}
