//-----------------------------------------------------------------------
// <copyright file="UserControl.cs" company="MyCompane">
//      Copyright PMI21.Team1 All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class user controls
    /// </summary>
    public static class UserControls
    {
        /// <summary>
        /// This method performs logging in.
        /// </summary>
        /// <param name="forLogin">Login that the current user has entered.</param>
        /// <param name="forPassword">Password that the current user has entered.</param>
        /// <returns>True if user is logged in.</returns>
        public static User Identify(string forLogin, string forPassword)
        {
            User toReturn = null;

            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            foreach (User user in db.Users)
            {
                if (user.Login == forLogin && user.Password == forPassword)
                {
                    toReturn = user;
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Method adds new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <returns>True if user was successfully added, false otherwise</returns>
        public static bool AddNewUser(string newName, string newPassword)
        {
            if (CheckNameExistence(newName) == true)
            {
                return false;
            }

            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            db.Add(new User(db.Users.Last().Id + 1, newName, newPassword, new List<int> { Constants.DefaultRoleId }));
            db.CommitUsers();

            return true;
        }

        /// <summary>
        /// Method adds new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <param name="rolesIdes">List of Ides of user's roles</param>
        /// <returns></returns>
        public static bool AddNewUser(string newName, string newPassword, List<int> rolesIdes)
        {
            if (CheckNameExistence(newName) == true)
            {
                return false;
            }

            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            db.Add(new User(db.Users.Last().Id + 1, newName, newPassword, rolesIdes));
            db.CommitUsers();

            return true;
        }

        /// <summary>
        /// Method adds new role to the user's role list
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <param name="roleId">The role's id to add</param>
        /// <returns>True if role was successfully added</returns>
        public static bool AddUsersRole(int userId, int roleId)
        {
            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            foreach (User user in db.Users)
            {
                if (user.Id == roleId)
                {
                    user.RolesId.Add(roleId);
                    return true;
                }
            }

            db.CommitUsers();

            return false;
        }

        /// <summary>
        /// Add new Role to database.
        /// </summary>
        /// <param name="roleId">Id of new Role.</param>
        /// <param name="roleName">Name of new Role.</param>
        /// <returns>True if ok, false otherwise.</returns>
        public static bool AddNewRole(int roleId, string roleName)
        {
            //At progress
            return false;
        }

        /// <summary>
        /// Method removes user's role 
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <param name="roleId">The role's id to remove</param>
        /// <returns>True if role was successfully removed </returns>
        public static bool RemoveUsersRole(int userId, int roleId)
        {
            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            foreach (User user in db.Users)
            {
                if (user.Id == userId)
                {
                    user.RolesId.Remove(roleId);
                    return true;
                }
            }

            db.CommitUsers();

            return false;
            
        }

        /// <summary>
        /// Get user from users base by its idNumber.
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <returns>User if exist, null pointer otherwise</returns>
        public static User GetUserById(int userId)
        {
            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            return db.GetUserById(userId);
        }

        /// <summary>
        /// Return a list of users by the role
        /// </summary>
        /// <param name="roleId">The role's id to check by</param>
        /// <returns>A list of users by the role</returns>
        public static System.Collections.Generic.List<User> GetUsersByRole(int roleId)
        {
            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            List<User> toReturn = null;

            foreach(User user in db.Users)
            {
                if (user.RolesId.Contains(roleId))
                    toReturn.Add(user);
            }

            return toReturn;
        }

        /// <summary>
        /// Get role from roles base by its idNumber.
        /// </summary>
        /// <param name="roleId">Role's idNumber</param>
        /// <returns>Role if exist, null pointer otherwise</returns>
        public static Role GetRoleById(int roleId)
        {
            //In progress.
            return null;
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="userId">id of the user to delete</param>
        /// <returns>false if there is no such user in the database</returns>
        public static bool DeleteUser(int userId)
        {
            bool success = false;

            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            success = db.Users.Remove(db.GetUserById(userId));

            db.CommitUsers();

            return success;
        }

        /// <summary>
        /// Checks if the current name is in the database
        /// </summary>
        /// <param name="nameToCheck">the name to search for</param>
        /// <returns>True if the name is found</returns>
        private static bool CheckNameExistence(string nameToCheck)
        {
            DataBase db = DataBase.GetInstance();
            db.SetConnections(Constants.PATH);
            db.LoadUsers();

            foreach (User user in db.Users)
            {
                if (user.Login== nameToCheck)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the current role's Id is in the database.
        /// </summary>
        /// <param name="roleId">The Id to search for.</param>
        /// <returns>True if the Id is found.</returns>
        private static bool CheckRoleExistence(int roleId)
        {
            //In progress.
            return false;
        }
    }
}
