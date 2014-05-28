//-----------------------------------------------------------------------
// <copyright file="Check.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// class Check save check with orders
    /// </summary>
    public class Check
    {
        /// <summary>
        /// id of order
        /// </summary>
        private int idOrder;

        /// <summary>
        /// id of user
        /// </summary>
        private int idUser;

        /// <summary>
        /// time of order
        /// </summary>
        private DateTime time;

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// Default Constructor of class 
        /// </summary>
        public Check()
        {
            this.idOrder = 0;
            this.idUser = 0;
            this.time = new DateTime();
        }

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// Instance constructor 
        /// </summary>
        /// <param name="idOrderVal">id of order</param>
        /// <param name="idUserVal">id of user</param>
        public Check(int idOrderVal, int idUserVal)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = new DateTime();
        }

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// </summary>
        /// <param name="idOrderVal">id of order</param>
        /// <param name="idUserVal">id of user</param>
        /// <param name="time">time</param>
        public Check(int idOrderVal, int idUserVal, DateTime time)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = time;
        }

        /// <summary>
        ///  id user
        /// </summary>
        public int IdUser
        {
            get
            {
                return this.idUser;
            }
        }

        /// <summary>
        /// Id order
        /// </summary>
        public int IdOrder
        {
            get
            {
                return this.idOrder;
            }
        }

        /// <summary>
        /// Time 
        /// </summary>
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }

        /// <summary>
        /// save check into xml documents
        /// </summary>
        /// <param name="path">path of xml document</param>
        public void Save(string path)
        {
            this.time = DateTime.Now;
            if (!File.Exists(path))
            {
                XmlWriter writer = XmlWriter.Create(path);
                writer.WriteStartElement("head");
                writer.WriteFullEndElement();
                writer.Close();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlElement newOrder = doc.CreateElement("OrderId");
            XmlElement newUser = doc.CreateElement("UserId");
            XmlElement newTime = doc.CreateElement("Time");
            XmlText orderId = doc.CreateTextNode(this.IdOrder.ToString());
            XmlText userId = doc.CreateTextNode(this.IdUser.ToString());
            XmlText checkTime = doc.CreateTextNode(this.time.ToString("o"));
            newOrder.AppendChild(orderId);
            newUser.AppendChild(userId);
            newTime.AppendChild(checkTime);
            root.InsertAfter(newOrder, root.LastChild);
            root.InsertAfter(newUser, root.LastChild);
            root.InsertAfter(newTime, root.LastChild);
            doc.Save(path);
        }

        /// <summary>
        /// save check to database
        /// </summary>
        /// <param name="doc">Xml Document</param>
        public void SaveCheckDB(XmlDocument doc)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("OrderId");
            XmlAttribute attrID = doc.CreateAttribute("order_id");
            attrID.Value = this.IdOrder.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement userID = doc.CreateElement("UserId");
            XmlElement time = doc.CreateElement("Time");
            XmlText uIDval = doc.CreateTextNode(this.IdUser.ToString());
            XmlText timeVal = doc.CreateTextNode(this.Time.ToString("o"));
            userID.AppendChild(uIDval);
            time.AppendChild(timeVal);
            root.InsertAfter(userID, root.LastChild);
            root.InsertAfter(time, root.LastChild);
        }
    }
}