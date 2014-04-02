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
    public class User
    {
        public User()
        {
            this.Password = "nopas";
            this.Login = "nologin";
            this.Role = null;
        }

        public User(string password, string login, RoleAndId role)
        {
            this.Password = password;
            this.Login = login;
            this.Role = new RoleAndId(role.Id, role.Duty);
        }

        public User(User p)
        {
            this.Password = p.Password;
            this.Login = p.Login;
            this.Role = p.Role;
        }

        public string Password { get; private set; }

        public string Login { get; private set; }

        public RoleAndId Role { get; private set; }
    }
}
