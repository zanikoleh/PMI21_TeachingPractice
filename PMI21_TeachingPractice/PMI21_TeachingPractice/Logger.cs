namespace UsersProj
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Logger
    {
        /// <summary>
        /// Logged user is the result of searching
        /// </summary>
        public User LoggedUser { get; private set; }

        /// <summary>
        /// This method performs logging in
        /// </summary>
        /// <param name="forLogin">login that the current user has entered</param>
        /// <param name="forPassword">password that the current user has entered</param>
        /// <returns>true if user is logged in</returns>
        public bool Login(string forLogin, string forPassword)
        {
            System.IO.StreamReader namepasfile = null;
            System.IO.StreamReader idrolefile = null;
            try
            {
                namepasfile = new System.IO.StreamReader("Base.csv");
                idrolefile = new System.IO.StreamReader("Idbase.csv");
                string namepasreader = null;
                string idrplereader = null;

                if (this.FindLogin(ref namepasreader, forLogin, namepasfile))
                {
                    if (this.CheckPassword(ref namepasreader, forPassword))
                    {

                        int tempId = this.GetInt(ref namepasreader);

                        Role tempRole = new Role(tempId, this.FindRole(ref idrplereader, tempId, idrolefile));

                        this.LoggedUser = new User(forPassword, forLogin, tempRole);
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }

            catch (System.IO.FileNotFoundException p)
            {
                Console.WriteLine(p.Message);
                return false;
            }
            catch (System.IO.IOException p)
            {
                Console.WriteLine(p.Message);
                return false;
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

            return true;
        }

        /// <summary>
        /// Looks for an appropriate login in the file
        /// </summary>
        /// <param name="allContent">current line that 'infile' reads</param>
        /// <param name="login">login that the user has entered</param>
        /// <param name="infile">input file</param>
        /// <returns>true if the login is found</returns>
        private bool FindLogin(ref string allContent, string login, System.IO.StreamReader infile) 
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
        private bool CheckPassword(ref string allContent, string password) 
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
        private int GetInt(ref string allContent) 
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
        private string FindRole(ref string allIds, int id, System.IO.StreamReader infile) // працює аналогічно bool findLogin, добавляє роль
        {

            int tempId = -1;
            while (tempId != id && !infile.EndOfStream)
            {
                allIds = infile.ReadLine();
                tempId = Convert.ToInt32(allIds.Substring(Constants.Zero, allIds.IndexOf(',')));
            }

            if (tempId != id)
            {
                return "No role!";
            }

            allIds = allIds.Remove(Constants.Zero, allIds.IndexOf(',') + Constants.One);

            int codeOfRole = this.GetInt(ref allIds);
            
            if (codeOfRole == Constants.One)// if code == 1 that is Admin
                return "Admin";

            if (codeOfRole == Constants.Two)// if code == 2 that is Client
                return "Client";

            if (codeOfRole == Constants.Three)// if code == 3 that is Trade agent
                return "TradeAgent";

            return "Any other Role";
        }
    }
}