namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class Role represents a role and id of a user
    /// </summary>
    public class Role
    {
        public Role()
        {
            this.Id = -1;
            this.Name = "Default";
        }

        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public override string ToString()
        {
            return this.Id + " " + this.Name;
        }
    }
}