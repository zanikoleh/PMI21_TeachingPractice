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
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
            UserControl uc = new UserControl();

            Console.WriteLine(uc.GetRoleById(2));
            Product p = new Product();
            XmlTextReader reader = new XmlTextReader(@"../../data/XMLFile1.xml");
            p.Read(reader);
            p.Write();
            XmlTextWriter writer = new XmlTextWriter("result.xml", Encoding.UTF8);
            p.Write(writer);
            Product n = new Product();
            p.Read(reader);
            p.Write();
            p.Write(writer);
            writer.Close();
            Console.WriteLine("\nPress any key to continue");
            System.Console.ReadKey();
        }
    }
}