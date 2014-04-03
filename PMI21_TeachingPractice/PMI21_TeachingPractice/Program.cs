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

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
            UserControl uc = new UserControl();

            uc.AddNewUser("login6", "password6");
            User u = uc.Identify("login6", "password6");
            Console.WriteLine(u);
        }
    }
}