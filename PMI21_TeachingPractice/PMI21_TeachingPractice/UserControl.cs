namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserControl
    {
        /// <summary>
        /// This method performs logging in.
        /// </summary>
        /// <param name="forLogin">Login that the current user has entered.</param>
        /// <param name="forPassword">Password that the current user has entered.</param>
        /// <returns>True if user is logged in.</returns>
        public User Identify(string forLogin, string forPassword)
        {
            System.IO.StreamReader baseUsers = null;
            try
            {
                baseUsers = new System.IO.StreamReader(Constants.BaseUsers);

                string lineReader = null;

                if (this.IdentifyLogin(ref lineReader, forLogin, baseUsers))
                {
                    if (this.IdentifyPassword(lineReader, forPassword))
                    {
                        return this.CreateUser(lineReader);
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
        public bool AddNewUser(string newName, string newPassword)
        {
            try
            {
                if (this.CheckNameExistence(newName))
                {
                    return false;
                }

                this.AddToDatabase(newName, newPassword);
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
        /// Looks for an appropriate login in the file
        /// </summary>
        /// <param name="allContent">current line that 'infile' reads</param>
        /// <param name="login">login that the user has entered</param>
        /// <param name="infile">input file</param>
        /// <returns>true if the login is found</returns>
        private bool IdentifyLogin(ref string allContent, string login, System.IO.StreamReader infile) 
        {
            string tempLogin = null;
            while (tempLogin != login && !infile.EndOfStream)
            {
                allContent = infile.ReadLine();
                tempLogin = allContent.Substring(allContent.IndexOf(',') + Constants.One, allContent.IndexOf(',', allContent.IndexOf(',') + Constants.One) - (allContent.IndexOf(',') + Constants.One));
            }

            return login == tempLogin;
        }

        /// <summary>
        /// Method parses current line and checks if the password is correct
        /// </summary>
        /// <param name="allContent">line</param>
        /// <param name="password">password that the user has entered</param>
        /// <returns>true if the password is correct</returns>
        private bool IdentifyPassword(string allContent, string password) 
        {
            allContent = allContent.Remove(Constants.Zero, allContent.IndexOf(',') + Constants.One);
            allContent = allContent.Remove(Constants.Zero, allContent.IndexOf(',') + Constants.One);
            string tempPassword = allContent.Substring(Constants.Zero, allContent.IndexOf(','));

            return password == tempPassword;
        }

        /// <summary>
        /// Create new instance of User class, using information from textline.
        /// </summary>
        /// <param name="textLine">Information about new instance of User class</param>
        /// <returns>User if OK, else null pointer</returns>
        private User CreateUser(string textLine)
        {
            try
            {
                int id = 0;
                string login = String.Empty;
                string password = String.Empty;
                int amountOfRoles = 0;
                List<int> rolesId = new List<int>();

                id = Convert.ToInt32(textLine.Substring(Constants.Zero, textLine.IndexOf(',')));
                textLine = textLine.Remove(Constants.Zero, textLine.IndexOf(',') + 1);

                login = textLine.Substring(Constants.Zero, textLine.IndexOf(','));
                textLine = textLine.Remove(Constants.Zero, textLine.IndexOf(',') + 1);

                password = textLine.Substring(Constants.Zero, textLine.IndexOf(','));
                textLine = textLine.Remove(Constants.Zero, textLine.IndexOf(',') + 1);

                amountOfRoles = Convert.ToInt32(textLine.Substring(Constants.Zero, textLine.IndexOf(',')));
                textLine = textLine.Remove(Constants.Zero, textLine.IndexOf(',') + 1);

                for (int i = 0; i < amountOfRoles - 1; i++)
                {
                    rolesId.Add(Convert.ToInt32(textLine.Substring(Constants.Zero, textLine.IndexOf(','))));
                    textLine = textLine.Remove(Constants.Zero, textLine.IndexOf(',') + 1);
                }

                rolesId.Add(Convert.ToInt32(textLine));

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
        /// Checks if the current name is in the database
        /// </summary>
        /// <param name="nameToCheck">the name to search for</param>
        /// <returns>true if the name is found</returns>
        private bool CheckNameExistence(string nameToCheck)
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
        /// Generates user's id
        /// </summary>
        /// <returns>new user's id</returns>
        private int IdGenerator()
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
        private void AddToDatabase(string newName, string newPassword)
        {
            string generatedId = Convert.ToString(this.IdGenerator());
            string forBaseUsers = generatedId + "," + newName + "," + newPassword + "," + "1" + "," + Constants.DEFAULT_ROLE_ID;

            System.IO.FileStream baseUsers = new System.IO.FileStream(Constants.BaseUsers, System.IO.FileMode.Append);
            System.IO.StreamWriter baseUsersFileWriter = new System.IO.StreamWriter(baseUsers);

            baseUsersFileWriter.WriteLine(forBaseUsers);

            baseUsersFileWriter.Close();
            baseUsers.Close();
        }

        /// <summary>
        /// Load all users from database.
        /// </summary>
        /// <param name="contentToLoad">Content load to.</param>
        /// <returns>True if loaded, false othewise.</returns>
        private bool LoadBaseUsers(out System.Collections.Generic.List<User> contentToLoad)
        {
            System.IO.StreamReader baseUsers = null;
            contentToLoad = null;
            try
            {
                baseUsers = new System.IO.StreamReader(Constants.BaseUsers);
                contentToLoad = new System.Collections.Generic.List<User>();

                string textLine = String.Empty;

                while (!baseUsers.EndOfStream)
                {
                    textLine = baseUsers.ReadLine();
                    contentToLoad.Add(this.CreateUser(textLine));
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