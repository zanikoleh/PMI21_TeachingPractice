//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        static void WorkFlow(UserControl uc)
        {
            try
            {
                Console.WriteLine("Type 1 to login type 0 to exit:");
                int start = Convert.ToInt32(Console.ReadLine());
                switch (start)
                {
                    case 1:
                        {
                            User logged=Login(uc,0);
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            catch (FormatException )
            {
                Console.WriteLine("You chose wrong option");
                WorkFlow(uc);
            }
        }
        static public User Login(UserControl uc, int count)
        {
            try
            {
                Console.WriteLine("login:");
                string login = Console.ReadLine();
                Console.WriteLine("password:");
                string password = Console.ReadLine();
                if (uc.Identify(login, password) == null)
                {
                    throw new ApplicationException("Wrong login or password");
                }
                return uc.Identify(login, password);
            }
            catch (ApplicationException e)
            {
                if (count < 3)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Type 1 to try again or 0 to exit");
                    string message = "You have only" + (3 - count).ToString() + "more attempts";
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                return Login(uc, 0);
                            }
                        case 0:
                            {
                                Environment.Exit(0);
                                return new User();
       
                            }
                    }
                }
                else
                {
                    Environment.Exit(0);
                    return new User();
                }
            }
        }
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
            UserControl uc = new UserControl();
            WorkFlow(uc);
        }
    }
}