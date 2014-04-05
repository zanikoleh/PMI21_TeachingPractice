//-----------------------------------------------------------------------
// <copyright file="FileStream.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using PMI21_TeachingPractice;

    /// <summary>
    /// describes streams of the files with data
    /// </summary>
    public class FileStream
    {
        /// <summary>
        /// stream of file with products to read
        /// </summary>
        private XmlTextReader readProducts;

        /// <summary>
        /// stream of file with identification data to read
        /// </summary>
        private StreamReader readBaseUsers;

        /// <summary>
        /// stream of file with id and roles to read
        /// </summary>
        private StreamReader readBaseRoles; 

        /// <summary>
        /// stream of xml file with orders to read
        /// </summary>
        private XmlTextReader readResult;

        /// <summary>
        /// path to the text file with orders to read
        /// </summary>
        private string readData;

        /// <summary>
        /// stream of file with orders to write
        /// </summary>
        private XmlDocument writeResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStream"/> class
        /// </summary>
        public FileStream()
        {
            this.readProducts = new XmlTextReader(@"../../data/XMLFile1.xml");
            this.readBaseUsers = new StreamReader(@"../../data/BaseUsers.csv");
            this.readBaseRoles = new StreamReader(@"../../data/BaseRoles.csv");
            this.readResult = new XmlTextReader(@"../../data/Result.xml");
            this.readData = @"../../data/Data.txt";
            this.writeResult = new XmlDocument();
            this.writeResult.Load(@"../../data/Result.xml");
        }

        /// <summary>
        /// Gets a stream of file with products to read 
        /// </summary>
        public XmlTextReader ReadProducts
        {
            get
            {
                return this.readProducts;
            }
        }

        /// <summary>
        /// Gets a stream of file with identification data to read
        /// </summary>
        public StreamReader ReadBaseUsers
        {
            get
            {
                return this.readBaseUsers;
            }
        }

        /// <summary>
        /// Gets a stream of file with id and roles to read
        /// </summary>
        public StreamReader ReadBaseRoles
        {
            get
            {
                return this.readBaseRoles;
            }
        }
        
        /// <summary>
        /// Gets a stream of xml file with orders to read
        /// </summary>
        public XmlTextReader ReadResult
        {
            get
            {
                return this.readResult;
            }
        }

        /// <summary>
        /// Gets a path to the text file with orders to read
        /// </summary>
        public string ReadData
        {
            get
            {
                return this.readData;
            }
        }

        /// <summary>
        /// Gets a stream of file with orders to write
        /// </summary>
        public XmlDocument WriteResult
        {
            get
            {
                return this.writeResult;
            }
        }
    }
}
