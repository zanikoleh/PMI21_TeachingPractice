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
        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
            this.Id = 0;
            this.Login = "nologin";
            this.Password = "nopas";
            this.RolesId = new List<int>();
        }

        /// <summary>
        /// Instance constructor
        /// </summary>
        /// <param name="Id">user's id</param>
        /// <param name="login">user's login</param>
        /// <param name="password">user's password</param>
        /// <param name="roleId">the list of roles' ids'</param>
        public User(int Id, string login, string password, List<int> roleId)
        {
            this.Id = Id;
            this.Login = login;
            this.Password = password;
            this.RolesId = roleId;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="p">the instance of class User</param>
        public User(User p)
        {
            this.Id = p.Id;
            this.Login = p.Login;
            this.Password = p.Password;
            this.RolesId = p.RolesId;
        }

        /// <summary>
        /// gets or sets user's id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// gets or sets user's login
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        /// gets or sets user's password
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// List of IDes of roles.
        /// </summary>
        public List<int> RolesId { get; private set; }

        /// <summary>
        /// Method converts an object to its string representation so that it is suitable for display
        /// </summary>
        /// <returns>a string that represents the current object</returns>
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
