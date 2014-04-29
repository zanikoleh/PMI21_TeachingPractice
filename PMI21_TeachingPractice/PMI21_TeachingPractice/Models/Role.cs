//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="MyCompane">
//      Copyright PMI21.Team1 All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
            this.Id = -1;
            this.Name = "Default";
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="id">role's id</param>
        /// <param name="name">role's name</param>
        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets, sets role's id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets, sets role name
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
