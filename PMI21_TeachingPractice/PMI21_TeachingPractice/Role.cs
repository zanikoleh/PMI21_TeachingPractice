namespace UsersProj
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class Role represents a role and id of a user
    /// </summary>
    class Role
    {
        public int Id { get; private set; }
        public string Duty { get; private set; }

        public Role()
        {
            this.Id = -1;
            this.Duty = "norole";
        }

        public Role(int id, string duty)
        {
            this.Id = id;
            this.Duty = duty;
        }
    }
}

