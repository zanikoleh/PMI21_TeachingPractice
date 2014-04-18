﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMI21_TeachingPractice
{
    static public class Application
    {
        static private User Login(UserControl uc, int count)
        {
            try
            {
                Console.WriteLine("login:");
                string login = Console.ReadLine();
                Console.WriteLine("password:");
                string password = Console.ReadLine();
                if (uc.Identify(login, password) == null)
                {
                    if (count < 3)
                    {
                        Console.WriteLine("Wrong login or password");
                        Console.WriteLine("Press 0 to exit");
                        string message = "You have only " + (3 - count).ToString() + " more attempts";
                        Console.WriteLine(message);
                        char choice = Convert.ToChar(Console.ReadLine());
                        switch (choice)
                        {
                            case '0':
                                {
                                    Environment.Exit(0);
                                    return new User();
                                }
                            default:
                                {
                                    return Login(uc, count+1);
                                }
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                        return new User();
                    }
                }
                return uc.Identify(login, password);
            }
            catch (FormatException)
            {
                return Login(uc, count + 1);
            }
        }
        static public void WorkFlow(UserControl uc)
        {
            try
            {
                Console.WriteLine("Type 1 to login type 0 to exit:");
                int start = Convert.ToInt32(Console.ReadLine());
                switch (start)
                {
                    case 1:
                        {
                            User logged = Application.Login(uc, 0);
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You chose wrong option");
                WorkFlow(uc);
            }
        }
    }
}
