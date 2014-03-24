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
        /// Logged user - the result of searching
        /// </summary>
        public User LoggedUser { get; private set; }

        public bool Login(string forLogin, string forPassword) // виконує логінування
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
                        int tempId = this.GetID(ref namepasreader);
                        string tempRole = this.FindRole(ref idrplereader, tempId, idrolefile);
                        this.LoggedUser = new User(forLogin, tempId, forPassword, tempRole);
                    }
                }
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
            catch (Exception p)
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

        private bool FindLogin(ref string allContent, string login, System.IO.StreamReader infile) // зчитує з файлу по 1 рядку і парсить шукаючи збіг із введеним ім ям якшо нема то ексепшн
        {
            string tempLogin = null;
            while (tempLogin != login && !infile.EndOfStream)
            {
                allContent = infile.ReadLine();
                tempLogin = allContent.Substring(0, allContent.IndexOf(','));
            }

            if (tempLogin != login)
            {
                throw new Exception("Username not found!"); 
            }

            allContent = allContent.Remove(0, allContent.IndexOf(',') + 1);
            return true;
        }

        private bool CheckPassword(ref string allContent, string password) // метод парсить зчитаний рядок дальше і провіряє чи правильний пароль
        {
            string tempPassword = allContent.Substring(allContent.IndexOf(',') + 1, allContent.Length - 2);
            if (tempPassword != password) 
            {
                throw new Exception("Invalid password!"); 
            }

            allContent = allContent.Remove(allContent.IndexOf(','), allContent.Length - 1);
            return true;
        }

        private int GetID(ref string allContent) // метод парсить зчитаний рядок дальше і дістає id даного юзера
        {
            return Convert.ToInt32(allContent);
        }

        private string FindRole(ref string allIds, int id, System.IO.StreamReader infile) // працює аналогічно bool findLogin, добавляє роль
        {
            int tempId = -1;
            while (tempId != id && !infile.EndOfStream)
            {
                allIds = infile.ReadLine();
                tempId = Convert.ToInt32(allIds.Substring(0, allIds.IndexOf(',')));
            }

            if (tempId != id)
            {
                throw new Exception("Id registry error!"); 
            }

            return allIds.Substring(allIds.IndexOf(',') + 1, allIds.Length - 2);
        }
    }
}
