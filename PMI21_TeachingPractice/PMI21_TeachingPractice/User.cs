namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class User represents a user =)
    /// </summary>
    public class User
    {
        public User()
        {
            this.Id = 0;
            this.Login = "nologin";
            this.Password = "nopas";
            this.RolesId = new List<int>();
        }

        public User(int Id, string login, string password, List<int> roleId)
        {
            this.Id = Id;
            this.Login = login;
            this.Password = password;
            this.RolesId = roleId;
        }

        public User(User p)
        {
            this.Id = p.Id;
            this.Login = p.Login;
            this.Password = p.Password;
            this.RolesId = p.RolesId;
        }

        public int Id { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        /// <summary>
        /// List of IDes of roles.
        /// </summary>
        public List<int> RolesId { get; private set; }

        public override string ToString()
        {
            string textLine = string.Empty;

            textLine = this.Id + " " + this.Login + " " + this.Password;
            foreach (int i in this.RolesId)
                textLine += (" " + i);

            return textLine;
        }
    }
}
