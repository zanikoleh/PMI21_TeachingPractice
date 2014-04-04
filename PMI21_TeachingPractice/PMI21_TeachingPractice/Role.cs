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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Role()
        {
            this.Id = -1;
            this.Name = "Default";
        }

        /// <summary>
        /// Instance constructor
        /// </summary>
        /// <param name="id">role's id</param>
        /// <param name="name">role's name</param>
        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// gets or sets role's id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// gets or sets role name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Method converts an object to its string representation so that it is suitable for display
        /// </summary>
        /// <returns>a string that represents the current object</returns>
        public override string ToString()
        {
            return this.Id + " " + this.Name;
        }
    }
}