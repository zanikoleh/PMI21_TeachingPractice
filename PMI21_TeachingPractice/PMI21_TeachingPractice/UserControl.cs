namespace UsersProj
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
        /// This method performs logging in
        /// </summary>
        /// <param name="forLogin">login that the current user has entered</param>
        /// <param name="forPassword">password that the current user has entered</param>
        /// <returns>true if user is logged in</returns>
        public User Identify(string forLogin, string forPassword)
        {
            System.IO.StreamReader namepasfile = null;
            System.IO.StreamReader idrolefile = null;
            try
            {
                namepasfile = new System.IO.StreamReader(Constants.BaseFile);
                idrolefile = new System.IO.StreamReader(Constants.IdRegistry);
                string namepasreader = null;
                string idrplereader = null;

                if (this.IdentifyLogin(ref namepasreader, forLogin, namepasfile))
                {
                    if (this.IdentifyPassword(ref namepasreader, forPassword))
                    {
                        int tempId = this.IdentifyId(ref namepasreader);

                        RoleAndId tempRole = new RoleAndId(tempId, this.IdentifyRole(ref idrplereader, tempId, idrolefile));

                        return new User(forPassword, forLogin, tempRole);
                    }
                    else
                    {
                        return new User();
                    }
                }
                else
                {
                    return new User();
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
                if (namepasfile != null)
                {
                    namepasfile.Close();
                }

                if (idrolefile != null)
                {
                    idrolefile.Close();
                }
            }
        }

        /// <summary>
        /// Method adds new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <returns>true if the name is not found in database</returns>
        public bool AddNewUser(string newName, string newPassword)
        {
            System.IO.FileStream toBase = null;
            System.IO.FileStream toIdRegistry = null;
            System.IO.StreamWriter baseFileWriter = null;
            System.IO.StreamWriter idRegistryWriter = null;

            try
            {
                if (this.CheckNameExistence(newName))
                {
                    return false;
                }

                toBase = new System.IO.FileStream(Constants.BaseFile, System.IO.FileMode.Append);
                toIdRegistry = new System.IO.FileStream(Constants.IdRegistry, System.IO.FileMode.Append);
                baseFileWriter = new System.IO.StreamWriter(toBase);
                idRegistryWriter = new System.IO.StreamWriter(toIdRegistry);
                this.AddToDatabase(newName, newPassword, baseFileWriter, idRegistryWriter);
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
                if (baseFileWriter != null)
                {
                    baseFileWriter.Close();
                }

                if (idRegistryWriter != null)
                {
                    idRegistryWriter.Close();
                }

                if (toBase != null)
                {
                    toBase.Close();
                }

                if (toIdRegistry != null)
                {
                    toIdRegistry.Close();
                }
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
                tempLogin = allContent.Substring(Constants.Zero, allContent.IndexOf(','));
            }

            if (tempLogin != login)
            {
                return false;
            }

            allContent = allContent.Remove(Constants.Zero, allContent.IndexOf(',') + Constants.One);
            return true;
        }

        /// <summary>
        /// Method parses current line and checks if the password is correct
        /// </summary>
        /// <param name="allContent">line</param>
        /// <param name="password">password that the user has entered</param>
        /// <returns>true if the password is correct</returns>
        private bool IdentifyPassword(ref string allContent, string password) 
        {
            string tempPassword = allContent.Substring(allContent.IndexOf(',') + Constants.One, allContent.Length - Constants.Two);
            if (tempPassword != password)
            {
                return false;
            }

            allContent = allContent.Remove(allContent.IndexOf(','), allContent.Length - Constants.One);
            return true;
        }

        /// <summary>
        /// Method parses current line and get it's string representation
        /// </summary>
        /// <param name="allContent">contents of the line</param>
        /// <returns>user's ID in an integer form</returns>
        private int IdentifyId(ref string allContent) 
        {
            return Convert.ToInt32(allContent);
        }

        /// <summary>
        /// Adds a role
        /// </summary>
        /// <param name="allIds">all IDs, line that is read by 'infile'</param>
        /// <param name="id">current id</param>
        /// <param name="infile">input file</param>
        /// <returns>appropriate role</returns>
        private Constants.Roles IdentifyRole(ref string allIds, int id, System.IO.StreamReader infile) // працює аналогічно bool findLogin, добавляє роль
        {
            int tempId = -1;
            while (tempId != id && !infile.EndOfStream)
            {
                allIds = infile.ReadLine();
                tempId = Convert.ToInt32(allIds.Substring(Constants.Zero, allIds.IndexOf(',')));
            }

            if (tempId != id)
            {
                return Constants.Roles.NoRole;
            }

            allIds = allIds.Remove(Constants.Zero, allIds.IndexOf(',') + Constants.One);

            int codeOfRole = this.IdentifyId(ref allIds);
            //// if code == 1 that is Admin
            if (codeOfRole == (int)Constants.Roles.Admin)
            {
                return Constants.Roles.Admin;
            }
            //// if code == 2 that is Client
            if (codeOfRole == (int)Constants.Roles.Client)
            {
                return Constants.Roles.Client;
            }
            //// if code == 3 that is Trade agent
            if (codeOfRole == (int)Constants.Roles.TradeAgent)
            {
                return Constants.Roles.TradeAgent;
            }

            return Constants.Roles.NoRole;
        }

        /// <summary>
        /// Checks if the current name is in the database
        /// </summary>
        /// <param name="nameToCheck">the name to search for</param>
        /// <returns>true if the name is found</returns>
        private bool CheckNameExistence(string nameToCheck)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Constants.BaseFile);
            string temp = null;
            while (temp != nameToCheck && !reader.EndOfStream)
            {
                temp = reader.ReadLine();
                temp = temp.Substring(Constants.Zero, temp.IndexOf(','));
            }

            reader.Close();
            if (temp == nameToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates user's id
        /// </summary>
        /// <returns>new user's id</returns>
        private int IdGenerator()
        {
            int temp;
            System.IO.StreamReader reader = new System.IO.StreamReader(Constants.UsersNumber);
            temp = int.Parse(reader.ReadLine());
            temp++;
            reader.Close();
            return temp;
        }

        /// <summary>
        /// Adds new user to the list of previous users
        /// </summary>
        /// <param name="num"></param>
        private void UsersNumberIncreaser(int num)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(new System.IO.FileStream(Constants.UsersNumber, FileMode.Truncate));
            writer.WriteLine(num);
            writer.Close();
        }

        /// <summary>
        /// Adds a new user to database
        /// </summary>
        /// <param name="newName">new user's name</param>
        /// <param name="newPassword">new user's password</param>
        /// <param name="baseFileWriter"></param>
        /// <param name="idRegistryWriter"></param>
        private void AddToDatabase(string newName, string newPassword, System.IO.StreamWriter baseFileWriter, System.IO.StreamWriter idRegistryWriter)
        {
            string generatedId = Convert.ToString(this.IdGenerator());
            string forBaseFile = newName + "," + generatedId + "," + newPassword;
            string forIdRegistry = generatedId + "," + Convert.ToString(Constants.Two);
            baseFileWriter.WriteLine(forBaseFile);
            idRegistryWriter.WriteLine(forIdRegistry);
            this.UsersNumberIncreaser(Convert.ToInt32(generatedId));
        }

        public void LoadDatabase(out System.Collections.Generic.List<User> contToLoad, System.IO.StreamReader users, System.IO.StreamReader ids)
        {
            contToLoad = new System.Collections.Generic.List<User>();
            string temp1, temp2;
            while (!users.EndOfStream && !ids.EndOfStream)
            {
                temp1 = users.ReadLine();
                temp2 = ids.ReadLine();
                contToLoad.Add(new User(this.CreateUserForList(temp1, temp2)));
            }
        }

        private User CreateUserForList(string part1, string part2)
        {
            string tempLogin, tempPassword;
            int tempId, codeOfRole;
            Constants.Roles tempRole;

            tempLogin = part1.Substring(0, part1.IndexOf(','));
            part1 = part1.Remove(Constants.Zero, part1.IndexOf(',') + Constants.One);
            tempId = Convert.ToInt32(part1.Substring(0, part1.IndexOf(',')));
            part1 = part1.Remove(Constants.Zero, part1.IndexOf(',') + Constants.One);
            tempPassword = part1;
            part2 = part2.Remove(Constants.Zero, part2.IndexOf(',') + Constants.One);

            codeOfRole = Convert.ToInt32(part2);

            //// if code == 1 that is Admin
            if (codeOfRole == (int)Constants.Roles.Admin)
            {
                tempRole =  Constants.Roles.Admin;
            }
            //// if code == 2 that is Client
            else if (codeOfRole == (int)Constants.Roles.Client)
            {
                tempRole = Constants.Roles.Client;
            }
            //// if code == 3 that is Trade agent
            else if (codeOfRole == (int)Constants.Roles.TradeAgent)
            {
                tempRole = Constants.Roles.TradeAgent;
            }
            else
            {
                tempRole = Constants.Roles.NoRole;
            }

            return new User(tempPassword, tempLogin, new RoleAndId (tempId, tempRole));
        }
    }
}