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
    public class RoleAndId
    {
        public RoleAndId()
        {
            this.Id = -1;
            this.Duty = Constants.Roles.NoRole;
        }

        public RoleAndId(int id, Constants.Roles duty)
        {
            this.Id = id;
            this.Duty = duty;
        }

        public int Id { get; private set; }

        public Constants.Roles Duty { get; private set; }
    }
}