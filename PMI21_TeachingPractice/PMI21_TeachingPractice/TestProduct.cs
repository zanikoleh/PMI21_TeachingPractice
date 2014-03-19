//-----------------------------------------------------------------------
// <copyright file="TestProduct.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Class to test Product.
    /// </summary>
    public class TestProduct
    {
        /// <summary>
        /// Main function.
        /// </summary>
        public static void Run()
        {
            Product p = new Product();
            XmlTextReader reader = new XmlTextReader(@"C:\Users\Oleh\Documents\Visual Studio 2012\Projects\ОБЧ\ОБЧ\XMLFile1.xml");
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