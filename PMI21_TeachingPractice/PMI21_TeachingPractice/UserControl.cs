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
    /// class user control
    /// </summary>
    public static class UserControl
    {
        /// <summary>
        /// This method performs logging in.
        /// </summary>
        /// <param name="forLogin">Login that the current user has entered.</param>
        /// <param name="forPassword">Password that the current user has entered.</param>
        /// <returns>True if user is logged in.</returns>
        public static User Identify(string forLogin, string forPassword)
        {
            System.IO.StreamReader baseUsers = null;
            try
            {
                baseUsers = new System.IO.StreamReader(Constants.BaseUsers);

                string lineReader = null;

                if (UserControl.IdentifyLogin(ref lineReader, forLogin, baseUsers))
                {
                    if (UserControl.IdentifyPassword(lineReader, forPassword))
                    {
                        return UserControl.CreateUser(lineReader);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (System.IO.FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return new User();
            }
            catch (System.IO.IOException p)
            {
                Console.WriteLine(p.Message);
                return new User();
            }
            finally
            {
                if (baseUsers != null)
                {
                    baseUsers.Close();
                }
            }
        }

        /// <summary>
        /// Method adds new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <returns>True if user was successfully added, false otherwise</returns>
        public static bool AddNewUser(string newName, string newPassword)
        {
            try
            {
                if (UserControl.CheckNameExistence(newName))
                {
                    return false;
                }

                UserControl.AddToBaseUsers(newName, newPassword);
            }
            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }

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
            if (UserControl.CheckNameExistence(newName))
            {
                return false;
            }

            return UserControl.AddToBaseUsers(newName, newPassword, rolesIdes);
        }

        /// <summary>
        /// Method adds new role to the user's role list
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <param name="roleId">The role's id to add</param>
        /// <returns>True if role was successfully added</returns>
        public static bool AddUsersRole(int userId, int roleId)
        {
            System.Collections.Generic.List<User> baseUsers = null;
            bool success = false;
            UserControl.LoadBaseUsers(out baseUsers);

            foreach (User x in baseUsers)
            {
                if (x.Id == userId && !x.RolesId.Contains(roleId))
                {
                    x.RolesId.Add(roleId);
                    success = true;
                    break;
                }
            }

            UserControl.ExportBaseUsers(baseUsers);
            return success;
        }

        /// <summary>
        /// Add new Role to database.
        /// </summary>
        /// <param name="roleId">Id of new Role.</param>
        /// <param name="roleName">Name of new Role.</param>
        /// <returns>True if ok, false otherwise.</returns>
        public static bool AddNewRole(int roleId, string roleName)
        {
            if (UserControl.CheckRoleExistence(roleId))
            {
                return false;
            }

            return UserControl.AddToBaseRoles(roleId, roleName);
        }


        /// <summary>
        /// Method removes user's role 
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <param name="roleId">The role's id to remove</param>
        /// <returns>True if role was successfully removed </returns>
        public static bool RemoveUsersRole(int userId, int roleId)
        {
            System.Collections.Generic.List<User> baseUsers = null;
            bool success = false;
            UserControl.LoadBaseUsers(out baseUsers);

            foreach (User x in baseUsers)
            {
                if (x.Id == userId)
                {
                    if ((x.RolesId.Count > Constants.One) && x.RolesId.Contains(roleId))
                    {
                        x.RolesId.Remove(roleId);
                        success = true;
                        break;
                    }
                }
            }

            UserControl.ExportBaseUsers(baseUsers);
            return success;
        }

        /// <summary>
        /// Get user from users base by its idNumber.
        /// </summary>
        /// <param name="userId">User's idNumber</param>
        /// <returns>User if exist, null pointer otherwise</returns>
        public static User GetUserById(int userId)
        {
            System.IO.StreamReader baseUsers = new System.IO.StreamReader(Constants.BaseUsers);

            string textLine = string.Empty;
            string idReader = string.Empty;

            while (Convert.ToString(userId) != idReader && !baseUsers.EndOfStream)
            {
                textLine = baseUsers.ReadLine();
                idReader = textLine.Substring(Constants.Zero, textLine.IndexOf(','));
            }

            baseUsers.Close();

            if (Convert.ToString(userId) == idReader)
            {
                return UserControl.CreateUser(textLine);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Return a list of users by the role
        /// </summary>
        /// <param name="roleId">The role's id to check by</param>
        /// <returns>A list of users by the role</returns>
        public static System.Collections.Generic.List<User> GetUsersByRole(int roleId)
        {
            System.IO.StreamReader baseUsers = new System.IO.StreamReader(Constants.BaseUsers);
            System.Collections.Generic.List<User> toReturn = new System.Collections.Generic.List<User>();

            string textLine = string.Empty;
            User temp;
            while (!baseUsers.EndOfStream)
            {
                textLine = baseUsers.ReadLine();
                temp = new User(UserControl.CreateUser(textLine));
                if (temp.RolesId.Contains(roleId))
                {
                    toReturn.Add(temp);
                }
            }

            baseUsers.Close();
            return toReturn;
        }

        /// <summary>
        /// Get role from roles base by its idNumber.
        /// </summary>
        /// <param name="roleId">Role's idNumber</param>
        /// <returns>Role if exist, null pointer otherwise</returns>
        public static Role GetRoleById(int roleId)
        {
            System.IO.StreamReader baseRoles = new System.IO.StreamReader(Constants.BaseRoles);

            string textLine = string.Empty;
            string idReader = string.Empty;

            while (Convert.ToString(roleId) != idReader && !baseRoles.EndOfStream)
            {
                textLine = baseRoles.ReadLine();
                idReader = textLine.Substring(Constants.Zero, textLine.IndexOf(','));
            }

            baseRoles.Close();

            if (Convert.ToString(roleId) == idReader)
            {
                return new Role(Convert.ToInt32(idReader), textLine.Substring(textLine.IndexOf(',') + 1));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="userId">id of the user to delete</param>
        /// <returns>false if there is no such user in the database</returns>
        public static bool DeleteUser(int userId)
        {
            System.Collections.Generic.List<User> baseUsers = null;
            bool success = false;
            UserControl.LoadBaseUsers(out baseUsers);
            foreach (User x in baseUsers)
            {
                if (x.Id == userId)
                {
                    baseUsers.Remove(x);
                    success = true;
                    break;
                }
            }

            UserControl.ExportBaseUsers(baseUsers);
            return success;
        }

        /// <summary>
        /// Looks for an appropriate login in the file
        /// </summary>
        /// <param name="allContent">current line that 'inFile' reads</param>
        /// <param name="login">login that the user has entered</param>
        /// <param name="inFile">input file</param>
        /// <returns>true if the login is found</returns>
        private static bool IdentifyLogin(ref string allContent, string login, System.IO.StreamReader inFile)
        {
            string tempLogin = null;
            while (tempLogin != login && !inFile.EndOfStream)
            {
                allContent = inFile.ReadLine();
                tempLogin = allContent.Substring(allContent.IndexOf(',') + Constants.One, allContent.IndexOf(',', allContent.IndexOf(',') + Constants.One) - (allContent.IndexOf(',') + Constants.One));
            }

            return login == tempLogin;
        }

        /// <summary>
        /// /// Method parses current line and checks if the password is correct
        /// </summary>
        /// <param name="allContent">The source of the event.</param>
        /// <param name="password">The <see cref="password"/> instance containing the event data.</param>
        /// <returns> true if the password is correct </returns>
        private static bool IdentifyPassword(string allContent, string password)
        {
            allContent = allContent.Remove(Constants.Zero, allContent.IndexOf(',') + Constants.One);
            allContent = allContent.Remove(Constants.Zero, allContent.IndexOf(',') + Constants.One);
            string tempPassword = allContent.Substring(Constants.Zero, allContent.IndexOf(','));          

            return password == tempPassword;
        }

        /// <summary>
        /// Create new instance of User class, using information from text line.
        /// </summary>
        /// <param name="tape">Information about new instance of User class</param>
        /// <returns>User if User was successfully created, else null pointer</returns>
        private static User CreateUser(string tape)
        {
            try
            {
                int id = 0;
                string login = string.Empty;
                string password = string.Empty;
                int amountOfRoles = 0;
                List<int> rolesId = new List<int>();

                id = Convert.ToInt32(tape.Substring(Constants.Zero, tape.IndexOf(',')));
                tape = tape.Remove(Constants.Zero, tape.IndexOf(',') + 1);

                login = tape.Substring(Constants.Zero, tape.IndexOf(','));
                tape = tape.Remove(Constants.Zero, tape.IndexOf(',') + 1);

                password = tape.Substring(Constants.Zero, tape.IndexOf(','));
                tape = tape.Remove(Constants.Zero, tape.IndexOf(',') + 1);

                amountOfRoles = Convert.ToInt32(tape.Substring(Constants.Zero, tape.IndexOf(',')));
                tape = tape.Remove(Constants.Zero, tape.IndexOf(',') + 1);

                for (int i = 0; i < amountOfRoles - 1; i++)
                {
                    rolesId.Add(Convert.ToInt32(tape.Substring(Constants.Zero, tape.IndexOf(','))));
                    tape = tape.Remove(Constants.Zero, tape.IndexOf(',') + 1);
                }

                rolesId.Add(Convert.ToInt32(tape));

                return new User(id, login, password, rolesId);
            }
            catch (System.NullReferenceException)
            {
                return null;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return null;
            }
            catch (System.FormatException)
            {
                return null;
            }
            catch (System.ArgumentException)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a string which contains all the information about the user
        /// </summary>
        /// <param name="user">The <see cref="user"/> .</param>
        /// <returns>a string which contains all the information about the user</returns>
        private static string CreateLineUserRepresentation(User user)
        {
            string toReturn = user.Id + "," + user.Login + "," + user.Password + "," + user.RolesId.Count;
            foreach (int x in user.RolesId)
            {
                toReturn += "," + x;
            }

            return toReturn;
        }

        /// <summary>
        /// Checks if the current name is in the database
        /// </summary>
        /// <param name="nameToCheck">the name to search for</param>
        /// <returns>True if the name is found</returns>
        private static bool CheckNameExistence(string nameToCheck)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Constants.BaseUsers);
            string temp = null;
            while (temp != nameToCheck && !reader.EndOfStream)
            {
                temp = reader.ReadLine();
                temp = temp.Substring(temp.IndexOf(',') + 1, temp.IndexOf(',', temp.IndexOf(',') + 1) - Constants.Two);
            }

            reader.Close();

            return temp == nameToCheck;
        }

        /// <summary>
        /// Checks if the current role's Id is in the database.
        /// </summary>
        /// <param name="roleId">The Id to search for.</param>
        /// <returns>True if the Id is found.</returns>
        private static bool CheckRoleExistence(int roleId)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Constants.BaseRoles);

            string temp = null;
            while (Convert.ToInt32(temp) != roleId && !reader.EndOfStream)
            {
                temp = reader.ReadLine();
                temp = temp.Substring(0, temp.IndexOf(','));
            }

            reader.Close();

            return Convert.ToInt32(temp) == roleId;
        }

        /// <summary>
        /// Generates user's id
        /// </summary>
        /// <returns>new user's id</returns>
        private static int IdGenerator()
        {
            int id;
            string line = string.Empty;

            System.IO.StreamReader baseUsers = new System.IO.StreamReader(Constants.BaseUsers);

            while (!baseUsers.EndOfStream)
            {
                line = baseUsers.ReadLine();
            }

            baseUsers.Close();

            id = Convert.ToInt32(line.Substring(Constants.Zero, line.IndexOf(','))) + 1;

            return id;
        }

        /// <summary>
        /// Adds a new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <returns>True if user was successfully added, false otherwise.</returns>
        private static bool AddToBaseUsers(string newName, string newPassword)
        {
            try
            {
                string generatedId = Convert.ToString(UserControl.IdGenerator());
                string forBaseUsers = generatedId + "," + newName + "," + newPassword + "," + "1" + "," + Constants.DefaultRoleId;

                System.IO.FileStream baseUsers = new System.IO.FileStream(Constants.BaseUsers, System.IO.FileMode.Append);
                System.IO.StreamWriter baseUsersFileWriter = new System.IO.StreamWriter(baseUsers);

                baseUsersFileWriter.WriteLine(forBaseUsers);

                baseUsersFileWriter.Close();
                baseUsers.Close();
            }

            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a new user to database
        /// </summary>
        /// <param name="newName">New user's name.</param>
        /// <param name="newPassword">New user's password.</param>
        /// <param name="rolesIdes">List of Ides of user's roles.</param>
        /// <returns>True if user was successfully added, false otherwise.</returns>
        private static bool AddToBaseUsers(string newName, string newPassword, List<int> rolesIdes)
        {
            try
            {
                string generatedId = Convert.ToString(UserControl.IdGenerator());
                string forBaseUsers = generatedId + "," + newName + "," + newPassword;

                foreach (int roleId in rolesIdes)
                {
                    forBaseUsers += "," + roleId;
                }

                System.IO.FileStream baseUsers = new System.IO.FileStream(Constants.BaseUsers, System.IO.FileMode.Append);
                System.IO.StreamWriter baseUsersFileWriter = new System.IO.StreamWriter(baseUsers);

                baseUsersFileWriter.WriteLine(forBaseUsers);

                baseUsersFileWriter.Close();
                baseUsers.Close();
            }
            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds new role to database.
        /// </summary>
        /// <param name="roleId">New role's Id.</param>
        /// <param name="roleName">New role's name.</param>
        /// <returns>True if role was successfully added, false otherwise.</returns>
        private static bool AddToBaseRoles(int roleId, string roleName)
        {
            try
            {
                System.IO.FileStream baseRoles = new System.IO.FileStream(Constants.BaseRoles, System.IO.FileMode.Append);
                System.IO.StreamWriter baseRolesFileWriter = new System.IO.StreamWriter(baseRoles);

                baseRolesFileWriter.WriteLine(roleId + ',' + roleName);

                baseRolesFileWriter.Close();
                baseRoles.Close();
            }
            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Load all users from database.
        /// </summary>
        /// <param name="contentToLoad">Content load to.</param>
        /// <returns>True if loaded, false otherwise</returns>
        private static bool LoadBaseUsers(out System.Collections.Generic.List<User> contentToLoad)
        {
            System.IO.StreamReader baseUsers = null;
            contentToLoad = null;
            try
            {
                baseUsers = new System.IO.StreamReader(Constants.BaseUsers);
                contentToLoad = new System.Collections.Generic.List<User>();

                string textLine = string.Empty;

                while (!baseUsers.EndOfStream)
                {
                    textLine = baseUsers.ReadLine();
                    contentToLoad.Add(UserControl.CreateUser(textLine));
                }
            }
            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            finally
            {
                if (baseUsers != null)
                {
                    baseUsers.Close();
                }
            }

            return true;
        }

        /// <summary>
        /// Loads information from the list into the file
        /// </summary>
        /// <param name="contentToExport">list with users</param>
        /// <returns>true if operation was successful</returns>
        private static bool ExportBaseUsers(System.Collections.Generic.List<User> contentToExport)
        {
            System.IO.StreamWriter baseUsers = null;
            try
            {
                baseUsers = new System.IO.StreamWriter(Constants.BaseUsers);
                foreach (User x in contentToExport)
                {
                    baseUsers.WriteLine(UserControl.CreateLineUserRepresentation(x));
                }
            }
            catch (FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            finally
            {
                if (baseUsers != null)
                {
                    baseUsers.Close();
                }
            }

            return true;
        }
    }
}
